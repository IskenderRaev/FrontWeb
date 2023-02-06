using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Links.Queries;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    
    public class OtherLinks : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetAllLinksQueryUI() { LinkType = StiGovKg.Domain.Enums.LinkType.Others });
            return View(items);
        }
    }
}
