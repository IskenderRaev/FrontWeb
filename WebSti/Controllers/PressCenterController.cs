using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Galleries.Queries;
using StiGovKg.Application.MediatR.News.Queries;
using StiGovKg.Application.MediatR.PressReleases.Queries.GetPressReleases;
using StiGovKg.Application.MediatR.Video.Queries.GetVideosToClientSide;
using System.Threading.Tasks;

namespace WebSti.Controllers
{
    public class PressCenterController : BaseController
    {
        public PressCenterController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public async Task<IActionResult> News(GetNewsQueryUI query)
        {
            ViewData["News"] = await Mediator.Send(query);

            return View(query);
        }
        public async Task<IActionResult> PressRelease(GetPressReleasesQuery query)
        {
            ViewData["PressRelease"] = await Mediator.Send(query);

            return View(query);
        }
        public async Task<IActionResult> VideoGallery(GetVideosQueryUI query)
        {
            ViewData["VideoGallery"] = await Mediator.Send(query);

            return View(query);
        }
        public async Task<IActionResult> PhotoGallery(GetGalleriesQueryUI query)
        {
            ViewData["PhotoGallery"] = await Mediator.Send(query);

            return View(query);
        }
    }
}
