using Shared.Core.Interfaces;
using Shared.Core.Models;
using System.Net.Http.Json;

namespace Shared.Core.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly HttpClient _client;

        public DictionaryService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("DictionaryClient");
        }

        public async Task<List<RayonDto>> GetRayons()
        {
            var response = await _client.GetAsync($"/api/tpregistration/coderayon");
            var rayons = await response.Content.ReadFromJsonAsync<List<RayonDto>>();
            return rayons.Where(x => x.Id != "000").ToList();  
        }
    }
}