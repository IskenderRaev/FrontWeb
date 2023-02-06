using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using static System.Environment;
using System.Globalization;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.Common.Constants;
using Shared.Core;
using StiGovKg.Infrastructure;
using StiGovKg.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace WebSti
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services
                .AddRouting(options => options.LowercaseUrls = true)
                .AddNotyf(config => { config.DurationInSeconds = 30; config.IsDismissable = true; config.Position = NotyfPosition.TopCenter; });

            services
                .AddSharedServices(Configuration)
                .AddStiGovKgInfrastructure(Configuration)
                .AddStiGovKgApplication()
                .AddWebConfiguration();

            var serviceProvider = services.BuildServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var languages = languageService.GetLanguages();
            var cultures = languages.Select(x => (new CultureInfo(x.Culture))).ToArray();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var englishCulture = cultures.FirstOrDefault(x => x.Name == WebStiLanguages.Kyrgyz);
                options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? WebStiLanguages.Kyrgyz);

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization();

            string path = Path.Combine(GetFolderPath(SpecialFolder.MyDocuments, SpecialFolderOption.DoNotVerify), "var", "www", "files", "sti");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(path),
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration["StsStorage:BasePath"]),
                RequestPath = "/stsStorage"
            });

            app.UseCookiePolicy();

            app.UseRouting();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseNotyf();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
