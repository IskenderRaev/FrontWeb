using StiGovKg.Domain.Entities;

namespace StiGovKg.Application.Common.Interfaces
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey, int languageId);
    }
}
