using StiGovKg.Application.Common.Dtos;
using StiGovKg.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StiGovKg.Infrastructure.ExternalServices
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly HttpClient _httpClient;

        public CurrencyRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyData> GetCurrencyAsync()
        {
            var response = await _httpClient.GetAsync("");

            var body = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<CurrencyData>(body); ;

            return result;
        }
    }
}
