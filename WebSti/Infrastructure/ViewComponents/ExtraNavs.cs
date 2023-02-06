using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections;
using System.Linq;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class ExtraNavs : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetExtraSubsectionQuery() { SectionType = StiGovKg.Domain.Enums.SectionType.Nav });
            return View(items.OrderBy(i => i.SubsectionOrder).Skip(6).ToList());
        }
    }
}
