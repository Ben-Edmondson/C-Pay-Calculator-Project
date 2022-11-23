using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using log4net;
using log4net.Config;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermanentEmployeeController : ControllerBase
    {
        PermanentCalculations permCalc = new PermanentCalculations();
        private static readonly ILog log = LogManager.GetLogger(typeof(PermanentEmployeeController));
        private readonly IEmployeeRepository<PermanentEmployee> _employeePermanentRepository;
        public PermanentEmployeeController(IEmployeeRepository<PermanentEmployee> employeePermanentRepository)
        {
            _employeePermanentRepository = employeePermanentRepository;
        }
        // GET: api/<EmployeeController>
        [Route("PermanentEmployees")]
        [HttpGet]
        public IActionResult GetAll()
        {
            BasicConfigurator.Configure();
            log.Info("Getting All Employees!.");
            List<PermanentEmployee> employees = _employeePermanentRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() == 0)
            {
                log.Warn("Failed to get employees. List Empty?");
                return NotFound();
            }
            log.Debug("Obtained employees.");
            return Ok(x);
        }
        // GET api/<EmployeeController>/5
        [Route("PermanentEmployee/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            log.Info("Getting singular Employee with ID provided.");
            PermanentEmployee? employee = _employeePermanentRepository.Read(id);
            if (employee != null)
            {
                PermamentEmployeeSalary? empWSal = new PermamentEmployeeSalary { Employee = employee, SalaryAfterTax = employee.Salary - permCalc.TotalTaxPaid(employee) };
                var ReadSingle = JsonSerializer.Serialize(empWSal);
                log.Debug("Obtained employee.");
                return Ok(ReadSingle);
            }
            log.Warn("Failed to get employees. Wrong ID used likely.");
            return NotFound();
        }
        // POST api/<EmployeeController>
        [Route("NewPermanentEmployee")]
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? Salary, decimal? Bonus)
        {
            log.Info("Creating new employee with provided details.");
            _employeePermanentRepository.Create(FirstName, Surname, Salary, Bonus, null, null);
            log.Debug("Employee Created!");
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        [Route("UpdatePermanentEmployee/{id}")]
        [HttpPut]
        public IActionResult Put(int id, string? FirstName, string? Surname, decimal? Salary, decimal? Bonus)
        {
            log.Info("Updating employee with corresponding ID.");
            if (_employeePermanentRepository.Update(id, FirstName, Surname, Salary, Bonus, null, null) == true)
            {
                log.Debug("Employee Updated!");
                return NoContent();
            }
            log.Warn("Update failed. False ID provided.");
            return NotFound();
        }
        // DELETE api/<EmployeeController>/5
        [Route("DeletePermanentEmployee/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            log.Info("Deleting employee with provided ID");
            if (_employeePermanentRepository.Delete(id) == true)
            {
                log.Debug("Employee Deleted!");
                return NoContent();
            }
            log.Warn("Failed to delete. Employee with ID not found.");
            return NotFound();
        }

        [Route("WipeEmployees")]
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            log.Info("Deleting all employees");
            if (_employeePermanentRepository.RemoveAll() == true)
            {
                log.Debug("Employees Wiped");
                return NoContent();
            }
            log.Warn("Failed to wipe employees. List already empty.");
            return NotFound();
        }
    }
}
