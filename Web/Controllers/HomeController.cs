using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Repository;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository<PermanentEmployeeRepo> _permRepo;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository<PermanentEmployeeRepo> permRepo)
        {
            _logger = logger;
            _permRepo = permRepo;
        }

        public IActionResult Index()
        {
            return View(_permRepo.ReadAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}