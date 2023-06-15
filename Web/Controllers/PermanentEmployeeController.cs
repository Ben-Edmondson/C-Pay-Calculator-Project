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
        PermanentEmployeeTaxCalculator permCalc = new PermanentEmployeeTaxCalculator();
        DateCalculator dateCalculations = new DateCalculator();
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

        public IActionResult EmployeeListDeleteConfirmed()
        {
            PermanentEmployeeViewModel permView = new PermanentEmployeeViewModel(_permRepo.ReadAll());
            return View(permView);
        }

        [HttpPost]  
        public IActionResult AddEmployee(PermanentEmployee inputEmployee)
        {
            _permRepo.Create(inputEmployee.StartDate, inputEmployee.FirstName, inputEmployee.LastName, inputEmployee.Salary, inputEmployee.Bonus, null, null);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult DeleteEmployee(int id)
        {
            if(_permRepo.Delete(id) == true)
            {
                return RedirectToAction("EmployeeListDeleteConfirmed");
            }
            return RedirectToAction("InvalidID", "Error");
        }

        public IActionResult UpdateEmployee(int id)
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
            _permRepo.Update(updateEmployee.ID,updateEmployee.FirstName,updateEmployee.LastName,updateEmployee.Salary,updateEmployee.Bonus,null,null);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult ReadEmployee(int id)
        {
            List<PermanentEmployee> employees = new List<PermanentEmployee>(_permRepo.ReadAll());
            if (employees.Exists(x => x.ID == id) == true)
            {
                PermanentEmployee? employee = _permRepo.Read(id);
                int amountOfWeeksWorkedByEmployee = dateCalculations.WeeksWorkedSinceStartDate(employee, DateTime.Today);
                PermanentEmployeeSalary? empWSal = new PermanentEmployeeSalary { ID = employee.ID, FirstName = employee.FirstName, LastName = employee.LastName, Salary = employee.Salary, Bonus = employee.Bonus, SalaryAfterTax = employee.Salary - permCalc.TotalTaxPaid(employee), StartDate = employee.StartDate};
                DetailedPermanentEmployeeViewModel viewModel = new DetailedPermanentEmployeeViewModel(empWSal, amountOfWeeksWorkedByEmployee);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("InvalidID", "Error");
            }
 
        }
    }
}
