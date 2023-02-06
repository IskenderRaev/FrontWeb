using StiGovKg.Domain.Entities;
using System.Collections.Generic;

namespace StiGovKg.Application.Common.Interfaces
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
