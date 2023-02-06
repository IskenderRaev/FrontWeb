using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Entities;
using System.Linq;

namespace StiGovKg.Infrastructure.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStigovkgDbContext _context;

        public LocalizationService(IStigovkgDbContext context)
        {
            _context = context;
        }

        public StringResource GetStringResource(string resourceKey, int languageId)
        {
            return _context.StringResources.FirstOrDefault(x =>
                    x.Name.Trim().ToLower() == resourceKey.Trim().ToLower()
                    && x.LanguageId == languageId);
        }
    }
}
