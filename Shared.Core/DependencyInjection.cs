using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Extensions;
using Shared.Core.Interfaces;
using Shared.Core.Services;
using IDictionaryService = Shared.Core.Interfaces.IDictionaryService;

namespace Shared.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClients(configuration);
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IDictionaryService, DictionaryService>();

            return services;
        }
    }
}
