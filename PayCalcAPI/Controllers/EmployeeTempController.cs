using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using System.Text.Json;

namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTempController : ControllerBase
    {
        private readonly IEmployeeRepository<TemporaryEmployee> _employeeTemporaryRepository;

        public EmployeeTempController(IEmployeeRepository<TemporaryEmployee> employeeTemporaryRepository)
        {
            _employeeTemporaryRepository = employeeTemporaryRepository;
        }
        // GET: api/<EmployeeTempController>
        [Route ("~/api/TemporaryEmployee/GetAllEmployees")]
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
        [Route("~/api/TemporaryEmployee/GetEmployee/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            TemporaryEmployee? emp = _employeeTemporaryRepository.Read(id);
            var ReadSingle = JsonSerializer.Serialize(emp);
            if(emp == null)
            {
                return NotFound();
            }
            return Ok(ReadSingle);
        }
        // POST api/<EmployeeTempController>
        [Route("~/api/TemporaryEmployee/AddEmployee")]
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
        {
            _employeeTemporaryRepository.Create(FirstName, Surname, null, null, DayRate, WeeksWorked);
            return NoContent();
        }
        // PUT api/<EmployeeTempController>/5
        [Route("~/api/TemporaryEmployee/UpdateEmployee/{id}")]
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
        [Route("~/api/TemporaryEmployee/DeleteEmployee/{id}")]
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
        [Route("~/api/TemporaryEmployee/DeleteAllEmployees")]
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
