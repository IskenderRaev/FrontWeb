using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Links.Queries;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class UsefulLinks : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetAllLinksQueryUI() { LinkType = StiGovKg.Domain.Enums.LinkType.Useful });
            return View(items);
        }
    }
}
