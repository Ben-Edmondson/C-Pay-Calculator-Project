using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult InvalidID()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null, string? message = null)
        {

            if (statusCode == 404)
            {
                message = "Not Found";
            }else if (statusCode == 400)
            {
                message = "Bad Request";
            }else if (statusCode == 500)
            {
                message = "Internal Server Error";
            }

            var model = new ErrorCodeModel(statusCode, message);
            return View(model);
        }
    }
}
