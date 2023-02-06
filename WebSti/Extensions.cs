using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using WebSti.Infrastructure.Filters;
using System;
using System.IO.Compression;

namespace WebSti
{
    public static class Extensions
    {
        public static IServiceCollection AddWebConfiguration(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddHttpContextAccessor();
            services
                .AddControllersWithViews(option => option.Filters.Add(typeof(ValidationFilter)))
                .AddRazorRuntimeCompilation();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/admin/account/login");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/admin/account/login";
                options.LogoutPath = "/admin/account/logout";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            return services;
        }
    }
}