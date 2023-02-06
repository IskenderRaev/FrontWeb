using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace WebSti.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                Controller controller = context.Controller as Controller;
                object model = context.ActionArguments.Any()
                   ? context.ActionArguments.First().Value
                   : null;

                context.Result = (IActionResult)controller?.View(model) ?? new BadRequestResult();
                return;
            }
            await next();
        }
    }
}