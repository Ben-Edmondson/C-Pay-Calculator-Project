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
        public async Task<IActionResult> Add(string inputFirstName, string inputLastName, decimal inputSalary, decimal inputBonus)
        {
            _permRepo.Create(inputFirstName, inputLastName, inputSalary, inputBonus, null, null);
            return View("EmployeeList");
        }
    }
}
