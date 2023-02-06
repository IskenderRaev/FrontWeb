using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Infrastructure.ExternalServices;
using StiGovKg.Infrastructure.Persistance;
using StiGovKg.Infrastructure.Services;

namespace StiGovKg.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStiGovKgInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StiGovKgDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("StiGovKgConnectionWrite"),
                    b => b.MigrationsAssembly("Shared.Migrations")));

            services.AddScoped<IStigovkgDbContext>(provider => provider.GetService<StiGovKgDbContext>());

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<IStiGovKgDapperContext, StiGovKgDapperContext>();

            services.AddLocalization();

            services.AddControllersWithViews()
    .AddViewLocalization();

            services.AddHttpClient<ICurrencyRateService, CurrencyRateService>(client =>
            {
                client.BaseAddress = new Uri(configuration["CurrencyRateUrl"]);
            });
            return services;
        }
    }
}
