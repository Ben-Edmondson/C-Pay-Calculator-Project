using Microsoft.AspNetCore.Mvc;
using PayCalc_Class_Library.Repos.Persistent_Repository;
using PayCalc_Project.Models;
using PayCalc_Project.Services;
using Web.Models;

namespace Web.Controllers
{
    public class PermanentEmployeeController : Controller
    {
        private readonly IPersistentEmployeeRepository<PermanentEmployee> _permRepo;
        PermanentEmployeeTaxCalculator permCalc = new PermanentEmployeeTaxCalculator();
        DateCalculator dateCalculations = new DateCalculator();
        public PermanentEmployeeController(IPersistentEmployeeRepository<PermanentEmployee> permRepo)
        {
            _permRepo = permRepo;
        }

        public IActionResult EmployeeList()
        {
            PermanentEmployeeViewModel permView = new PermanentEmployeeViewModel(_permRepo.ReadAllEmployees());
            return View(permView);
        }
        public IActionResult EmployeeListDeleteConfirmed()
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
            _permRepo.AddEmployee(inputEmployee);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult DeleteEmployee(PermanentEmployee permanentEmployee)
        {
            _permRepo.DeleteEmployee(permanentEmployee);
            return RedirectToAction("EmployeeListDeleteConfirmed");
        }

        public IActionResult UpdateEmployee(PermanentEmployee permanentEmployee)
        {
            List<PermanentEmployee> employees = new List<PermanentEmployee>(_permRepo.ReadAll());
            if (employees.Exists(x => x.ID == id) == true)
            {
                PermanentEmployee employee = _permRepo.Read(id);
                return View(employee);
            }
            else
            {
                return RedirectToAction("InvalidID", "Error");
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployee(PermanentEmployee updateEmployee)
        {
            _permRepo.UpdateEmployee(updateEmployee);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult ReadEmployee(int id)
        {
            PermanentEmployee perm = _permRepo.GetEmployee(id);
            return View(perm);
        }
    }
}
