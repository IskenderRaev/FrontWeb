using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Documents.Queries;
using StiGovKg.Application.MediatR.Themes.Queries;
using System;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class Documents : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid themeId, string title, int year, bool prevYears, int index)
        {
            int sentYear;
            ViewData["TableId"] = index;
            ViewData["PrevYears"] = false;
            if (prevYears)
            {
                ViewData["PrevYears"] = true;
            }
            if(year==0)
            {
                ViewData["ActiveYear"] = DateTime.Now.Year;
            }
            else
            {
                ViewData["ActiveYear"] = year;
            }                      
            var themeDto = await Mediator.Send(new GetThemeByIdQuery { Id = themeId });           
            if ((themeDto.IsBreakdownByYear && themeDto.IsUrl && themeDto.IsAdditionalFile)
                || (themeDto.IsBreakdownByYear) || (themeDto.IsBreakdownByYear && themeDto.IsUrl) || (themeDto.IsBreakdownByYear && themeDto.IsAdditionalFile)) 
            {
                sentYear = DateTime.Now.Year;
            }
            else 
            {
                sentYear = 0;
            }
            var documents = await Mediator.Send(new GetDocumentsQuery { ThemeId = themeId, Title = title, DocumentYear = sentYear });
            return View((themeDto, documents));
        }
    }
}