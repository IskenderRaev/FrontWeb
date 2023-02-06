using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections;
using System.Linq;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class Navs : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetSubsectionsQuery() { SectionType = StiGovKg.Domain.Enums.SectionType.Nav });
            return View(items.OrderBy(i=>i.SubsectionOrder).Take(6).ToList());
        }
    }
}
