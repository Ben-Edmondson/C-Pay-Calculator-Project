using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using System.Text.Json;

namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<TemporaryEmployee> _employeeTemporaryRepository;
        TemporaryCalculations tempCalc = new TemporaryCalculations();
        public TemporaryEmployeeController(IEmployeeRepository<TemporaryEmployee> employeeTemporaryRepository)
        {
            _employeeTemporaryRepository = employeeTemporaryRepository;
        }
        // GET: api/<EmployeeTempController>
        [Route ("~/api/[controller]/GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TemporaryEmployee> employees = _employeeTemporaryRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() <= 0)
            {
                return NotFound();
            }
            return Ok(x);
        }
        // GET api/<EmployeeTempController>/5
        [Route("~/api/[controller]/GetEmployee/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            TemporaryEmployee? employee = _employeeTemporaryRepository.Read(id);
            if (employee != null)
            {
                TemporaryEmployeeSalary emp = new TemporaryEmployeeSalary { Employee = employee, SalaryAfterTax = (employee.DayRate * (5 * employee.WeeksWorked)) - tempCalc.TotalTaxPaid(employee) };
                var ReadSingle = JsonSerializer.Serialize(emp);
                return Ok(ReadSingle);
            }
            else
            {
                return NotFound();
            }
        }
        // POST api/<EmployeeTempController>
        [Route("~/api/[controller]/AddEmployee")]
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
        {
            _employeeTemporaryRepository.Create(FirstName, Surname, null, null, DayRate, WeeksWorked);
            return NoContent();
        }
        // PUT api/<EmployeeTempController>/5
        [Route("~/api/[controller]/UpdateEmployee/{id}")]
        [HttpPut]
        public IActionResult Put(int id, string? FirstName, string? Surname, decimal? DayRate, int? WeeksWorked)
        {
            if (_employeeTemporaryRepository.Update(id, FirstName, Surname, null, null, DayRate, WeeksWorked) == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        // DELETE api/<EmployeeTempController>/5
        [Route("~/api/[controller]/DeleteEmployee/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_employeeTemporaryRepository.Delete(id) == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        [Route("~/api/[controller]/DeleteAllEmployees")]
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            if (_employeeTemporaryRepository.RemoveAll() == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
