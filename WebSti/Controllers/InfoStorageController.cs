using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;

namespace WebSti.Controllers
{
    public class InfoStorageController : BaseController
    {
        public InfoStorageController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IncomeTax()
        {
            return View();
        }
    }
}