using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.News.Queries;
using System.Threading.Tasks;

namespace WebSti.Controllers
{
    public class NewsController : BaseController
    {
        public NewsController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public async Task<IActionResult> Index(GetNewsQueryUI query)
        {
            ViewData["News"] = await Mediator.Send(query);

            return View(query);
        }

        public async Task<IActionResult> Details(GetNewsQueryByIdUI query)
        {
            var dto = await Mediator.Send(query);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        public async Task<IActionResult> PressCenter(GetNewsQueryUI query)
        {
            ViewData["News"] = await Mediator.Send(query);

            return View(query);
        }
    }
}