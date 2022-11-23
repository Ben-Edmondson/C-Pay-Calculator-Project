using log4net;
using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using System.Reflection;
using System.Text.Json;

namespace PayCalcAPI.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class TemporaryEmployeeController : ControllerBase
    {
        private readonly ILog _log;
        private readonly IEmployeeRepository<TemporaryEmployee> _employeeTemporaryRepository;
        TemporaryCalculations tempCalc = new TemporaryCalculations();
        public TemporaryEmployeeController(IEmployeeRepository<TemporaryEmployee> employeeTemporaryRepository)
        {
            _employeeTemporaryRepository = employeeTemporaryRepository;
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        }
        // GET: api/<EmployeeTempController>
        [Route("TemporaryEmployees")]
        [HttpGet]
        public IActionResult GetAll()
        {
            _log.Info("Getting All Temporary Employees!.");
            List<TemporaryEmployee> employees = _employeeTemporaryRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() <= 0)
            {
                _log.Warn("HTTP:404 - Failed to get temporary employees. List Empty?");
                return NotFound();
            }
            _log.Debug("HTTP:200 - Obtained temporary employees.");
            return Ok(x);
        }
        // GET api/<EmployeeTempController>/5
        [Route("TemporaryEmployee/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            _log.Info("Getting singular temporary Employee with ID provided.");
            TemporaryEmployee? employee = _employeeTemporaryRepository.Read(id);
            if (employee != null)
            {
                TemporaryEmployeeSalary emp = new TemporaryEmployeeSalary { Employee = employee, SalaryAfterTax = (employee.DayRate * (5 * employee.WeeksWorked)) - tempCalc.TotalTaxPaid(employee) };
                var ReadSingle = JsonSerializer.Serialize(emp);
                _log.Debug("HTTP:200 - Obtained temporary employee.");
                return Ok(ReadSingle);
            }
            _log.Warn("HTTP:404 - Failed to get temporary employees. Wrong ID used likely.");
            return NotFound();
        }
        // POST api/<EmployeeTempController>
        [Route("AddTemporaryEmployee")]
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
        {
            _log.Info("Creating new temporary employee with provided details.");
            _employeeTemporaryRepository.Create(FirstName, Surname, null, null, DayRate, WeeksWorked);
            _log.Debug("HTTP:204 - temporary Employee Created!");
            return NoContent();
        }
        // PUT api/<EmployeeTempController>/5
        [Route("UpdateTemporaryEmployee/{id}")]
        [HttpPut]
        public IActionResult Put(int id, string? FirstName, string? Surname, decimal? DayRate, int? WeeksWorked)
        {
            _log.Info("Updating temporary employee with corresponding ID.");
            if (_employeeTemporaryRepository.Update(id, FirstName, Surname, null, null, DayRate, WeeksWorked) == true)
            {
                _log.Debug("HTTP:204 - Temporary Employee Updated!");
                return NoContent();
            }
            _log.Warn("HTTP:404 - Update failed. False ID provided.");

            return NotFound();
        }
        // DELETE api/<EmployeeTempController>/5
        [Route("DeleteTemporaryEmployee/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _log.Info("Deleting temporary employee with provided ID");
            if (_employeeTemporaryRepository.Delete(id) == true)
            {
                _log.Debug("HTTP:204 - Temporary Employee Deleted!");
                return NoContent();
            }
            _log.Warn("HTTP:404 - Failed to delete Temporary Employee with ID not found.");
            return NotFound();
        }
        [Route("WipeEmployees")]
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            _log.Info("Deleting All Temporary Employees");
            if (_employeeTemporaryRepository.RemoveAll() == true)
            {
                _log.Debug("HTTP:204 - Temporary Employees Wiped");
                return NoContent();
            }
            _log.Warn("HTTP:404 - Failed to wipe Temporary Employees. List already empty.");
            return NotFound();
        }
    }
}
