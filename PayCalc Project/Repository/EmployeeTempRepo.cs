using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PayCalc_Project.Factories;
using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class EmployeeTempRepo : IEmployeeRepository<EmployeeTemp>
    {

        public List<EmployeeTemp> employees = new List<EmployeeTemp>() {
           new EmployeeTemp() {ID = 1111, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };
        public bool Delete(int id)
        {
            if (employees.Exists(x => x.ID == id) == true)
            {
                employees.Remove(employees.Find(x => x.ID == id));
                return true;
            }
            return false;
        }

        public bool RemoveAll()
        {
            employees.Clear();
            if (employees.Count() > 0)
            {
                return false;
            }
            return true;
        }

        public EmployeeTemp AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeeTemp addNew = TempEmployeeFactory.CreateEmployee(FirstName, Surname, DayRate, WeeksWorked);
            return addNew;
        }

        public List<EmployeeTemp> ReadAll()
        {
            List<EmployeeTemp> ReadAll = employees;
            return ReadAll;
        }

        public EmployeeTemp? ReadSingle(int id)
        {
            EmployeeTemp? ReadSingle = employees.Find(x => x.ID == id);
            return ReadSingle;
        }

        public void Update(int index, string? FirstName, string? LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            if (String.IsNullOrEmpty(FirstName) == false)
            {
                employees[index].FirstName = FirstName;
            }
            if (String.IsNullOrEmpty(LastName) == false)
            {
                employees[index].LastName = LastName;
            }
            if (DayRate != null)
            {
                employees[index].DayRate = DayRate;
            }
            if (WeeksWorked != null)
            {
                employees[index].WeeksWorked = WeeksWorked;
            }
        }
    }
}
