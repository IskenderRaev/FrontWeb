using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSti.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using StiGovKg.Application.Common.Interfaces;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSearchItem;
using System.IO;
using Microsoft.Extensions.Configuration;
using StiGovKg.Application.MediatR.Offers.Commands.CreateOffer;
using StiGovKg.Application.MediatR.Notification.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using StiGovKg.Application.MediatR.Questionnaires.Commands.CreateQuestionnaire;
using WebSti.Infrastructure.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using StiGovKg.Application.MediatR.Calendar.Queries.GetCalendar;
using System.Collections;

namespace WebSti.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _path;
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _path = configuration.GetSection("StsStorage").GetValue<string>("BasePath");
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<JsonResult> GetAllEvents([FromQuery] GetAllNotificationsUI query)
        {
            var dto = await Mediator.Send(query);

            return Json(dto);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult SmartSalym()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );
            return LocalRedirect(returnUrl);
        }
        public async Task<IActionResult> SearchText([FromQuery] GetSearchTextQuery query)
        {
            var dto = await Mediator.Send(query);
            ViewData["SearchedItem"] = dto;
            return View(query);
        }
       
        public async Task<IActionResult> GetFile(GetCalendarQuery request)
        {
            var query = await Mediator.Send(request);
            return View(query);
        }

        [HttpGet]
        public IActionResult AcceptanceOfProposals()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AcceptanceOfProposals(CreateOfferCommands command)
        {     
            if (ModelState.IsValid)
            {
                var acceptance = await Mediator.Send(command);
                if (acceptance.Succeed)
                {
                    foreach (var message in acceptance.Messages) Notyf.Success(message);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, acceptance.Messages.ToArrayString());
                foreach (var message in acceptance.Messages) Notyf.Error(message);
            }
            return View(command);
        }

        [HttpGet]
        public async Task<IActionResult> Questionnaire() 
        {
            var rayons = await DictionaryService.GetRayons();
            ViewData["rayons"] = new SelectList(rayons, "Id", "DisplayText");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Questionnaire(CreateQuestionnaireCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);
                if (result.Succeed)
                {
                    foreach (var message in result.Messages) Notyf.Success(message);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, result.Messages.ToArrayString());
                foreach (var message in result.Messages) Notyf.Error(message);
            }
            return View(command);
        }        

        public IActionResult BoxAndBookOfComplaintsAndSuggestions()
        {
            return View();
        }

        public IActionResult PersonalReceptionOfCitizens()
        {
            return View();
        }
        public IActionResult ConsiderationOfСitizens()
        {
            return View();
        }
        public IActionResult HelpLine()
        {
            return View();
        }
        
    }
}