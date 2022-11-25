using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using log4net;
using System.Text.Json;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermanentEmployeeController : ControllerBase
    {
        private readonly ILog _log;
        PermanentCalculations permCalc = new PermanentCalculations();
        private readonly IEmployeeRepository<PermanentEmployee> _employeePermanentRepository;
        public PermanentEmployeeController(IEmployeeRepository<PermanentEmployee> employeePermanentRepository)
        {
            _employeePermanentRepository = employeePermanentRepository;
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetAll()
        {
            _log.Info("Getting All Permanent Employees!.");
            List<PermanentEmployee> employees = _employeePermanentRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() == 0)
            {
                _log.Warn("HTTP:404 - Failed to get permanent employees. List Empty?");
                return NotFound();
            }
            _log.Debug("HTTP:200 - Obtained permanent employees.");
            return Ok(x);
        }
        // GET api/<EmployeeController>/5
        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            _log.Info("Getting singular Permanent Employee with ID provided.");
            PermanentEmployee? employee = _employeePermanentRepository.Read(id);
            if (employee != null)
            {
                PermamentEmployeeSalary? empWSal = new PermamentEmployeeSalary { ID = employee.ID, FirstName = employee.FirstName,LastName = employee.LastName, SalaryAfterTax = employee.Salary - permCalc.TotalTaxPaid(employee) };
                var ReadSingle = JsonSerializer.Serialize(empWSal);
                _log.Debug("HTTP:200 - Obtained permanent employee.");
                return Ok(ReadSingle);
            }
            _log.Warn("HTTP:404 - Failed to get permanent employees. Wrong ID used likely.");
            return NotFound();
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? Salary, decimal? Bonus)
        {
            _log.Info("Creating new permanent employee with provided details.");
            _employeePermanentRepository.Create(FirstName, Surname, Salary, Bonus, null, null);
            _log.Debug("HTTP:204 - Permanent Employee Created!");
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, string? FirstName, string? Surname, decimal? Salary, decimal? Bonus)
        {
            _log.Info("Updating permanent employee with corresponding ID.");
            if (_employeePermanentRepository.Update(id, FirstName, Surname, Salary, Bonus, null, null) == true)
            {
                _log.Debug("HTTP:204 - Permanent Employee Updated!");
                return NoContent();
            }
            _log.Warn("HTTP:404 - Update failed. False ID provided.");
            return NotFound();
        }
        // DELETE api/<EmployeeController>/5
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _log.Info("Deleting permanent employee with provided ID");
            if (_employeePermanentRepository.Delete(id) == true)
            {
                _log.Debug("HTTP:204 - Permanent Employee Deleted!");
                return NoContent();
            }
            _log.Warn("HTTP:404 - Failed to delete Permanent Employee with ID not found.");
            return NotFound();
        }
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            _log.Info("Deleting All Permanent Employees");
            if (_employeePermanentRepository.RemoveAll() == true)
            {
                _log.Debug("HTTP:204 - Permanent Employees Wiped");
                return NoContent();
            }
            _log.Warn("HTTP:404 - Failed to wipe Permanent Employees. List already empty.");
            return NotFound();
        }
    }
}
