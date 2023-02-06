using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;

namespace WebSti.Controllers
{
    public class ReportController : BaseController
    {
        public ReportController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}