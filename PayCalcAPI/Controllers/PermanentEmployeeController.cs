using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace PayCalcAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class PermanentEmployeeController : ControllerBase
    {
        PermanentCalculations permCalc = new PermanentCalculations();
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
            List<PermanentEmployee> employees = _employeePermanentRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() == 0)
            {
                return NotFound();
            }
            return Ok(x);
        }
        // GET api/<EmployeeController>/5
        [Route("PermanentEmployee/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            PermanentEmployee? employee = _employeePermanentRepository.Read(id);
            if (employee != null)
            {
                PermamentEmployeeSalary? empWSal = new PermamentEmployeeSalary { Employee = employee, SalaryAfterTax = employee.Salary - permCalc.TotalTaxPaid(employee) };
                var ReadSingle = JsonSerializer.Serialize(empWSal);
                return Ok(ReadSingle);
            }
            return NotFound();
        }
        // POST api/<EmployeeController>
        [Route("NewPermanentEmployee")]
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? Salary, decimal? Bonus)
        {
            _employeePermanentRepository.Create(FirstName, Surname, Salary, Bonus, null, null);
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        [Route("UpdatePermanentEmployee/{id}")]
        [HttpPut]
        public IActionResult Put(int id, string? FirstName, string? Surname, decimal? Salary, decimal? Bonus)
        {
            if (_employeePermanentRepository.Update(id, FirstName, Surname, Salary, Bonus, null, null) == true)
            {
                return NoContent();
            }
            return NotFound();
        }
        // DELETE api/<EmployeeController>/5
        [Route("DeletePermanentEmployee/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_employeePermanentRepository.Delete(id) == true)
            {
                return NoContent();
            }
            return NotFound();
        }

        [Route("WipeEmployees")]
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            if (_employeePermanentRepository.RemoveAll() == true)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
