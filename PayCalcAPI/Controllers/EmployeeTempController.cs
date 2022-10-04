using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using System.Text.Json;

namespace PayCalcAPI.Controllers
{
    public class EmployeeTempController : Controller
    {
        // GET: EmployeeTempController

        EmployeeTempRepo _employeeTemporaryRepository = new EmployeeTempRepo();
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<EmployeeTemp> employees = _employeeTemporaryRepository.ReadAll();
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
            var ReadSingle = JsonSerializer.Serialize(_employeeTemporaryRepository.ReadSingle(id));
            if (ReadSingle == null)
            {
                return NotFound();
            }
            return Ok(ReadSingle);
        }
        // POST api/<EmployeeController>
        //POST == Create
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
        { 
            _employeeTemporaryRepository.employees.Add(_employeeTemporaryRepository.AddEmployee(FirstName, Surname, null, null, DayRate, WeeksWorked));
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, string FirstName, string Surname, decimal? DayRate, int? WeeksWorked)
        {
            if (_employeeTemporaryRepository.employees.Count() >= id)
            {
                _employeeTemporaryRepository.employees[id] = _employeeTemporaryRepository.Update(id, FirstName, Surname, null, null, DayRate, WeeksWorked);
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
            _employeeTemporaryRepository.RemoveAll();
            if (_employeeTemporaryRepository.employees.Count() == 0)
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
