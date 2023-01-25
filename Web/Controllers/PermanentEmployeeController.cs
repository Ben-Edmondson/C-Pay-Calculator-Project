using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using Web.Models;

namespace Web.Controllers
{
    public class PermanentEmployeeController : Controller
    {
        private readonly IEmployeeRepository<PermanentEmployee> _permRepo;
        PermanentCalculations permCalc = new PermanentCalculations();
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

        public IActionResult DeleteEmployee(int id)
        {
            _permRepo.Delete(id);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult UpdateEmployee(int id)
        {
            return View(_permRepo.Read(id));
        }

        [HttpPost]
        public IActionResult UpdateEmployee(PermanentEmployee updateEmployee)
        {
            _permRepo.Update(updateEmployee.ID,updateEmployee.FirstName,updateEmployee.LastName,updateEmployee.Salary,updateEmployee.Bonus,null,null);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult ReadEmployee(int id)
        {
            PermanentEmployee? employee = _permRepo.Read(id);
            PermanentEmployeeSalary? empWSal = new PermanentEmployeeSalary { ID = employee.ID, FirstName = employee.FirstName, LastName = employee.LastName, Salary = employee.Salary, Bonus = employee.Bonus, SalaryAfterTax = employee.Salary - permCalc.TotalTaxPaid(employee) };
            return View(empWSal);
        }
    }
}
