using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class EmployeeTempRepo : IEmployeeRepository<EmployeeTemp>
    {

        public List<EmployeeTemp> employees = new List<EmployeeTemp>() {
           new EmployeeTemp() { ID = Guid.NewGuid(), FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };
        public bool Delete(int id)
        {
            int EmployeeCount = employees.Count();
            employees.RemoveAt(id);
            if (employees.Count() >= EmployeeCount)
            {
                return false;
            }
            return true;
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
            EmployeeTemp addNew = new EmployeeTemp() { ID = Guid.NewGuid(), FirstName = FirstName, LastName = Surname, DayRate = DayRate, WeeksWorked = WeeksWorked};
            return addNew;
        }

        public List<EmployeeTemp> ReadAll()
        {
            List<EmployeeTemp> ReadAll = new List<EmployeeTemp>();
            for (int i = 0; i < employees.Count; i++)
            {
                ReadAll.Add(employees[i]);
            }
            return ReadAll;
        }

        public EmployeeTemp ReadSingle(int id)
        {
            if (employees.Count() > id)
            {

                EmployeeTemp ReadSingle = new EmployeeTemp() { ID = employees[id].ID, FirstName = employees[id].FirstName, LastName = employees[id].LastName, DayRate = employees[id].DayRate, WeeksWorked = employees[id].WeeksWorked };
                return ReadSingle;
            }
            return null;
        }

        public void Update(int index, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            employees[index].FirstName = FirstName;
            employees[index].LastName = LastName;
            employees[index].DayRate = DayRate;
            employees[index].WeeksWorked = WeeksWorked;
        }
    }
}
