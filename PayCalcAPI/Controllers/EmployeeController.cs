using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<EmployeePerm> Get()
        {
            List<EmployeePerm> employees = new List<EmployeePerm>();
            employees.Add(new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 });
            employees.Add(new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 });
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
        }
    }
}
