using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.News.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.ViewComponents
{
    public class ActualNews : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetActualNewsQueryUI());
            return View(items.Take(5).ToList());
        }
    }
}
