using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StiGovKg.Application.Common.Interfaces;

namespace WebSti.Controllers
{
    public class GuideController : BaseController
    {
        private readonly ILogger<GuideController> _logger;
        private readonly string _path;
        public GuideController(IConfiguration configuration, ILogger<GuideController> logger, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _path = configuration.GetSection("StsStorage").GetValue<string>("BasePath");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ElectronicSignature()
        {
            return View();
        }

        public IActionResult LegalEntity()
        {
            return View();
        }

        public IActionResult HowToAccess ()
        {
            return View();
        }

        public IActionResult registerindividual()
        {
            return View();
        }

        public IActionResult getpersonalaccount()
        {
            return View();
        }
    }
}
