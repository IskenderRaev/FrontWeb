using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Themes.Queries;
using StiGovKg.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class Themes : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid subsectionid, SectionType sectionType,Guid? themeId, int page)
        {
            var items = await Mediator.Send(new GetThemesQuery { SubsectionId  = subsectionid, Page = page });
            return View((items, sectionType, themeId));
        }
    }
}