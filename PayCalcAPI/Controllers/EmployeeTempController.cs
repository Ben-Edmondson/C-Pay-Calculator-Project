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
        TemporaryEmployeeRepo _employeeTemporaryRepository = new TemporaryEmployeeRepo();
        // GET: api/<EmployeeTempController>
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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ReadSingle = JsonSerializer.Serialize(_employeeTemporaryRepository.Read(id));
            if (ReadSingle == null)
            {
                return NotFound();
            }
            return Ok(ReadSingle);
        }
        // POST api/<EmployeeTempController>
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
        { 
            _employeeTemporaryRepository.Create(FirstName, Surname, null, null, DayRate, WeeksWorked));
            return NoContent();
        }
        // PUT api/<EmployeeTempController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
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
        [HttpDelete("{id}")]
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
