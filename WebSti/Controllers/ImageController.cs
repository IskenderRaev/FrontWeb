using MediatR;
using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Images.Queries;
using System.Threading.Tasks;

namespace WebSti.Controllers
{
    public class ImageController : BaseController
    {
        public ImageController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        public async Task<IActionResult> Index(GetImagesQueryUI query)
        {
            ViewData["Images"] = await Mediator.Send(query);

            return View(query);
        }
    }
}