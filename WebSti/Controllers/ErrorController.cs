using Microsoft.AspNetCore.Mvc;

namespace WebSti.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/{code:int}")]
        public IActionResult Index(int code)
        {
            return View(code);
        }
    }
}
