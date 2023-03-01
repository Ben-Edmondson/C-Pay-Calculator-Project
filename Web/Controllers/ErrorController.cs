using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult InvalidID()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View("NotFound");
        }
    }
}
