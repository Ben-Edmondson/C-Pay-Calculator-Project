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
    public class EmployeePermController : ControllerBase
    {
        EmployeePermRepo _employeePermanentRepository = new EmployeePermRepo();
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<EmployeePerm> employees = _employeePermanentRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() <= 0)
            {
                return NotFound();
            }
            return Ok(x);
        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ReadSingle = JsonSerializer.Serialize(_employeePermanentRepository.ReadSingle(id));
            if (ReadSingle == null)
            {
                return NotFound();
            }
            return Ok(ReadSingle);
        }
        // POST api/<EmployeeController>
        //POST == Create
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? Salary, decimal? Bonus)
        {
            _employeePermanentRepository.employees.Add(_employeePermanentRepository.AddEmployee(FirstName, Surname, Salary, Bonus, null, null));
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, string FirstName, string Surname, decimal? Salary, decimal? Bonus)
        {
            if (_employeePermanentRepository.employees.Count() >= id)
            {
                _employeePermanentRepository.employees[id] = _employeePermanentRepository.Update(id, FirstName, Surname, Salary, Bonus, null, null);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_employeePermanentRepository.Delete(id) == true)
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
            _employeePermanentRepository.RemoveAll();
            if (_employeePermanentRepository.employees.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return NotFound() ;
            }

        }
    }
}
