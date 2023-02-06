using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Documents.Queries;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections;
using StiGovKg.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebSti.Controllers
{
    public class SectionController : BaseController
    {
        public SectionController(ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
        }

        [Route("{sectionType:int}/{subsectionId:Guid?}")]
        [Route("{sectionType:int}/{subsectionId:Guid?}/{themeId:Guid?}/{page:int}")]
        public async Task<IActionResult> Index(SectionType sectionType, Guid? subsectionId, Guid? themeId, int page = 1)
        
        {
            var subsections = await Mediator.Send(new GetSubsectionsQuery {});
            if (!subsectionId.HasValue)
            {
                subsectionId = subsections.Select(x => x.Id).FirstOrDefault();
            }
            return View((subsectionId, subsections, sectionType, themeId, page));
        }        

        [Route("/TakeDocumentAsync")]
        public async Task<IActionResult> TakeDocumentAsync(Guid themeId, int year, bool prevYears)
        {
            var documents = await Mediator.Send(new GetDocumentsBreakByYearQuery { ThemeId = themeId, DocumentYear = year });
            
            return Ok(documents);
        }
    }
}