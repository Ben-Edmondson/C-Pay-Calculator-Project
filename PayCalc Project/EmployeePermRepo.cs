using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    class EmployeePermRepo : EmployeePerm
    {

        public List<EmployeePerm> employees = new List<EmployeePerm>() {
            new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 },
        };

        public bool AddPermanentEmployee(string FirstName, string Surname, decimal Salary, decimal Bonus)
        {
            employees.Add(new EmployeePerm() { ID = Guid.NewGuid(), FirstName = FirstName, LastName = Surname, Salary = Salary, Bonus = Bonus });
            return true;
        }
        public List<string> Read()
        {
            List<string> ReadAll = new List<string>();
            for (int i = 0; i < employees.Count; i++)
            {
                ReadAll.Add($"{employees[i].FullName} Status: Permanent Salary: {employees[i].Salary} Bonus {employees[i].Bonus}");
            }
            return ReadAll;
        }

        public string ReadSingle(int i)
        {
            if (employees.Count() > i)
            {

                    string ReadSingleEmployee = $"{employees[i].FullName} Status: Permanent Salary: {employees[i].Salary} Bonus {employees[i].Bonus} ";
                    return ReadSingleEmployee;
            }
            string Failed = "Failed to read, ID is too high.";
            return Failed;
        }

        public bool UpdatePerm(int i, string FirstName, string LastName, decimal Salary, decimal Bonus)
        {
            employees[i].FirstName = FirstName;
            employees[i].LastName = LastName;
            employees[i].Salary = Salary;
            employees[i].Bonus = Bonus;
            return true;
        }
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
    }
}
