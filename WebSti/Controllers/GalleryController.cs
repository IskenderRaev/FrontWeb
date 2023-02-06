using MediatR;
using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Galleries.Queries;
using System.Threading.Tasks;

namespace WebSti.Controllers
{
    public class GalleryController : BaseController
    {
        public GalleryController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public async Task<IActionResult> Index(GetGalleriesQueryUI query)
        {
            ViewData["Galleries"] = await Mediator.Send(query);

            return View(query);
        }
    }
}