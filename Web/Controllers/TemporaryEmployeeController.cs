using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using Web.Models;

namespace Web.Controllers
{
    public class TemporaryEmployeeController : Controller
    {
        TemporaryCalculations tempCalc = new TemporaryCalculations();
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
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(TemporaryEmployee inputEmployee)
        {
            _temporaryRepo.Create(inputEmployee.FirstName, inputEmployee.LastName, null, null, inputEmployee.DayRate, inputEmployee.WeeksWorked);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult DeleteEmployee(int id)
        {
            if (_temporaryRepo.Delete(id) == true)
            {
                return RedirectToAction("EmployeeList");
            }
            return RedirectToAction("InvalidID", "Home");
        }

        public IActionResult UpdateEmployee(int id)
        {
            List<TemporaryEmployee> employees = new List<TemporaryEmployee>(_temporaryRepo.ReadAll());
            if(employees.Exists(x => x.ID == id) == true){
                return View(_temporaryRepo.Read(id));
            }
            else
            {
                return RedirectToAction("InvalidID", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployee(TemporaryEmployee updateEmployee)
        {
            _temporaryRepo.Update(updateEmployee.ID, updateEmployee.FirstName, updateEmployee.LastName, null,null,updateEmployee.DayRate,updateEmployee.WeeksWorked);
            return RedirectToAction("EmployeeList");
        }
        public IActionResult ReadEmployee(int id)
        {
            List<TemporaryEmployee> employees = new List<TemporaryEmployee>(_temporaryRepo.ReadAll());
            if (employees.Exists(x => x.ID == id) == true)
            {
                TemporaryEmployee? employee = _temporaryRepo.Read(id);
                TemporaryEmployeeSalary? empWSal = new TemporaryEmployeeSalary { ID = employee.ID, FirstName = employee.FirstName, LastName = employee.LastName, DayRate = employee.DayRate, WeeksWorked = employee.WeeksWorked, SalaryAfterTax = (employee.DayRate * (5 * employee.WeeksWorked)) - tempCalc.TotalTaxPaid(employee) };
                return View(empWSal);
            }
            else
            {
                return RedirectToAction("InvalidID", "Home");
            }
        }
    }
}
