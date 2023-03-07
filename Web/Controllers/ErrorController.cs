using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult InvalidID()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
                ViewBag.StatusCode = statusCode.Value;
                return View();
        }
    }
}
