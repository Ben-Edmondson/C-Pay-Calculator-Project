using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    class EmployeeTempRepo
    {

        public List<EmployeeTemp> employees = new List<EmployeeTemp>() {
           new EmployeeTemp() { ID = Guid.NewGuid(), FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };

        public bool AddTempEmployee(string FirstName, string LastName, decimal DayRate, int WeeksWorked)
        {
            employees.Add(new EmployeeTemp() { ID = Guid.NewGuid(),FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked });
            return true;
        }

        public List<string> Read()
        {
            List<string> ReadAll = new List<string>();
            for (int i = 0; i < employees.Count; i++)
            {

                    ReadAll.Add($"{employees[i].FullName} Status: Temporary Day Rate: {employees[i].DayRate} Weeks Worked: {employees[i].WeeksWorked}");
               
            }
            return ReadAll;
        }

        public string ReadSingle(int i)
        {
            if (employees.Count() > i)
            {

                    string ReadSingleEmployee = $"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Day Rate: {employees[i].DayRate} Weeks Worked: {employees[i].WeeksWorked}";
                    return ReadSingleEmployee;

            }
            string Failed = "Failed to read, ID is too high.";
            return Failed;
        }

        public bool UpdateTemp(int i, string FirstName, string LastName, decimal DayRate, int WeeksWorked)
        {
            employees[i].FirstName = FirstName;
            employees[i].LastName = LastName;
            employees[i].DayRate = DayRate;
            employees[i].WeeksWorked = WeeksWorked;
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
