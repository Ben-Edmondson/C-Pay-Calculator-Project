using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//Postman
namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeePermRepo _employeePermanentRepository = new EmployeePermRepo();
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<EmployeePerm> employees = _employeePermanentRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count < 0)
            {
                return NoContent();
            }
            return Ok(x);
        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ReadSingle = JsonSerializer.Serialize(_employeePermanentRepository.ReadSingle(id));
            return Ok(ReadSingle);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeePerm employee)
        {
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return NoContent();
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeePermanentRepository.Delete(id);
        }
    }
}
