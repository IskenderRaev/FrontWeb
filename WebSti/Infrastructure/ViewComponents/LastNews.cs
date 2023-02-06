using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.News.Queries;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class LastNews : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetLastNewsUI());
            return View(items);
        }
    }
}