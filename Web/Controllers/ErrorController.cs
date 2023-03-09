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
            if (statusCode == 404)
            {
                ViewBag.ErrorMessage = "Not Found";
            }else if (statusCode == 400)
            {
                ViewBag.ErrorMessage = "Bad Request";
            }else if (statusCode == 500)
            {
                ViewBag.ErrorMessage = "Internal Server Error";
            }
            return View();
        }
    }
}
