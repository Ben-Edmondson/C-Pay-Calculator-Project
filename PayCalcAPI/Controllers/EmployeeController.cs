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
            EmployeePermRepo employeePerm = new EmployeePermRepo();
            List<EmployeePerm> employees = employeePerm.ReadAll();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            EmployeePermRepo employeePerm = new EmployeePermRepo();
            string ReadSingle = employeePerm.ReadSingle(id).ToString();
            return ReadSingle;
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
            EmployeePermRepo permRepo = new EmployeePermRepo();
            permRepo.Delete(id);
        }
    }
}
