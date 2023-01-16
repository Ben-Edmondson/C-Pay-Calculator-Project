using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Models;

namespace Web.Controllers
{
    public class PermanentEmployeeController : Controller
    {
        private readonly IEmployeeRepository<PermanentEmployee> _permRepo;
        public PermanentEmployeeController(IEmployeeRepository<PermanentEmployee> permRepo)
        {
            _permRepo = permRepo;
        }

        public IActionResult EmployeeList()
        {
            PermanentEmployeeViewModel permView = new PermanentEmployeeViewModel(_permRepo.ReadAll());
            return View(permView);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult AddEmployee(PermanentEmployee inputEmployee)
        {
            _permRepo.Create(inputEmployee.FirstName, inputEmployee.LastName, inputEmployee.Salary, inputEmployee.Bonus, null, null);
            return RedirectToAction("EmployeeList");
        }
    }
}
