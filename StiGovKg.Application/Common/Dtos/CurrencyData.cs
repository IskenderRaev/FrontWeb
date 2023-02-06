using System.Text.Json.Serialization;

namespace StiGovKg.Application.Common.Dtos
{
    public class CurrencyData
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("rates")]
        public Rate Rates { get; set; }

        [JsonPropertyName("last_update")]
        public string Last_Update { get; set; }
    }

    public class Rate
    {
        public string[] USD { get; set; }

        public string[] EUR { get; set; }

        public string[] RUB { get; set; }

        public string[] KZT { get; set; }

        public string[] UZS { get; set; }

        public string[] CNY { get; set; }

        public string[] GBP { get; set; }
    }
}