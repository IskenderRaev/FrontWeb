using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Themes.Queries;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace WebSti.Infrastructure.ViewComponents
{
    public class ThemeForTypeOfPerson : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid subsectionid)
        {
            var items = await Mediator.Send(new GetThemesQueryByPersonTypeUI { SubsectionId = subsectionid});
            return View(items.OrderBy(i => i.ThemeOrder).Take(5).ToList());
        }
    }
}
