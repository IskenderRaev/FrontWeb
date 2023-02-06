using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Infrastructure.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IStigovkgDbContext _context;

        public LanguageService(IStigovkgDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Languages.FirstOrDefault(x =>
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }
    }
}
