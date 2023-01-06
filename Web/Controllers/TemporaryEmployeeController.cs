using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Models;

namespace Web.Controllers
{
    public class TemporaryEmployeeController : Controller
    {
        private readonly IEmployeeRepository<TemporaryEmployee> _temporaryRepo;

        public TemporaryEmployeeController(IEmployeeRepository<TemporaryEmployee> tempRepo)
        {
            _temporaryRepo = tempRepo;
        }

        public IActionResult EmployeeList()
        {
            TemporaryEmployeeViewModel tempView = new TemporaryEmployeeViewModel(_temporaryRepo.ReadAll());
            return View(tempView);
        }
    }
}
