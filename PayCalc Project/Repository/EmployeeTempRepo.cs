using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    class EmployeeTempRepo : IEmployeeRepository<EmployeeTemp>
    {

        public List<EmployeeTemp> employees = new List<EmployeeTemp>() {
           new EmployeeTemp() { ID = Guid.NewGuid(), FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };
        public bool Delete(int i)
        {
            int EmployeeCount = employees.Count();
            employees.RemoveAt(i);
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

        EmployeeTemp IEmployeeRepository<EmployeeTemp>.ReadSingle(int i)
        {
            if (employees.Count() > i)
            {

                EmployeeTemp ReadSingle = new EmployeeTemp() { ID = employees[i].ID, FirstName = employees[i].FirstName, LastName = employees[i].LastName, DayRate = employees[i].DayRate, WeeksWorked = employees[i].WeeksWorked };
                return ReadSingle;
            }
            return null;
        }

        public EmployeeTemp Update(int i, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeeTemp employeePerm = new EmployeeTemp() { ID = employees[i].ID, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked};
            return employeePerm;
        }
    }
}
