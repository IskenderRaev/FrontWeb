using StiGovKg.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StiGovKg.Application.Common.Interfaces
{
    public interface IStigovkgDbContext
    {
        DbSet<News> News { get; set; }
        DbSet<Notifications> Notifications { get; set; }
        DbSet<Banner> Banners { get; set; }
        DbSet<DictRegion> DictRegions { get; set; }
        DbSet<DictPartner> DictPartners { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Subsection> Subsections { get; set; }
        DbSet<Theme> Themes { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Video> Videos { get; set; }
        DbSet<PressRelease> PressReleases { get; set; }
        public DbSet<NewsSliderImage> NewsSliderImage { get; set; }
        public DbSet<NewsImages> NewsImages { get; set; }
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

        Task<int> SaveChangesAsync(CancellationToken token);

        void SetEntityState(object entity, EntityState entityState);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}