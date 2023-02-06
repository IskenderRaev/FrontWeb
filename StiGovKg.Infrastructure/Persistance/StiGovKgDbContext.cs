using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Common;
using StiGovKg.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace StiGovKg.Infrastructure.Persistance
{
    public class StiGovKgDbContext : DbContext, IStigovkgDbContext
    {
        private IDbContextTransaction _currentTransaction;
        private readonly IDateTime _dateTime;

        public StiGovKgDbContext(DbContextOptions<StiGovKgDbContext> options,
            IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<News> News { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<DictRegion> DictRegions { get; set; }
        public DbSet<DictPartner> DictPartners { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subsection> Subsections { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<PressRelease> PressReleases { get; set; }
        public DbSet<NewsSliderImage> NewsSliderImage { get; set; }
        public DbSet<NewsImages> NewsImages { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<LinkMainImage> LinkImage { get; set; }
        public DbSet<LinkAdditionalImage> LinkAdditionalImage { get; set; }
        public DbSet<Leadership> Leadership { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<Offer> Offer { get; set; }
        public DbSet<TaxpayerCalendar> TaxpayerCalendar { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken())
        {
            Guid? userId = null;
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            string userIdVal = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userIdVal))
                userId = new Guid(userIdVal);

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = userId.Value;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = userId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(token);
        }

        public void SetEntityState(object entity, EntityState entityState)
        {
            base.Entry(entity).State = entityState;
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
                return;

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                await _currentTransaction?.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _currentTransaction?.RollbackAsync();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}