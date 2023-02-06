using MediatR;
using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Video.Queries.GetVideosToClientSide;
using System.Threading.Tasks;

namespace WebSti.Controllers
{
    public class VideoController : BaseController
    {
        public VideoController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public async Task<IActionResult> Index(GetVideosQueryUI query)
        {
            ViewData["Videos"] = await Mediator.Send(query);

            return View(query);
        }
    }
}