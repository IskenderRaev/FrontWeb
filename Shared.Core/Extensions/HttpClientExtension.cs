using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace Shared.Core.Extensions
{
    public static class HttpClientExtension
    {
        internal static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var dictToken = configuration.GetSection("ServiceUrls:DictionaryService");

            services.AddHttpClient("DictionaryClient", client =>
            {
                client.BaseAddress = new Uri(dictToken.Value);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });           

            return services;
        }
    }
}
