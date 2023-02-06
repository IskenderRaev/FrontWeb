using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Documents.Queries;
using StiGovKg.Application.MediatR.Themes.Queries;
using System;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class Leadership : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid themeId, string title, int year, bool prevYears)
        {
            ViewData["PrevYears"] = false;
            if (prevYears)
            {
                ViewData["PrevYears"] = true;
            }
            ViewData["ActiveYear"] = year;
            var themeDto = await Mediator.Send(new GetThemeByIdUIQuery { Id = themeId });
            var documents = await Mediator.Send(new GetDocumentsQuery { ThemeId = themeId, Title = title, DocumentYear = year });
            return View((themeDto, documents));
        }
    }
}