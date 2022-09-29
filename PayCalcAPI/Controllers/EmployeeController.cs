using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetAll() 
        {
            EmployeePermRepo employeePerm = new EmployeePermRepo();
            List<EmployeePerm> employees = employeePerm.ReadAll();
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
            EmployeePermRepo employeePerm = new EmployeePermRepo();
            string ReadSingle = employeePerm.ReadSingle(id).ToString();
            var x = JsonSerializer.Serialize(ReadSingle);
            return Ok(x);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public List<EmployeePerm> Post([FromBody] EmployeePerm employee)
        {
            return null;
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeePermRepo permRepo = new EmployeePermRepo();
            permRepo.Delete(id);
        }
    }
}
