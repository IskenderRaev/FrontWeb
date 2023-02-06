using StiGovKg.Application.Common.Dtos;
using System.Threading.Tasks;

namespace StiGovKg.Application.Common.Interfaces
{
    public interface ICurrencyRateService
    {
        Task<CurrencyData> GetCurrencyAsync();
    }
}