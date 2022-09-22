using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    class EmployeePermRepo : IEmployeeRepository<EmployeePerm>
    {

        public List<EmployeePerm> employees = new List<EmployeePerm>() {
            new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 },
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

        public EmployeePerm AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeePerm addNew = new EmployeePerm() {ID = Guid.NewGuid(),FirstName = FirstName, LastName = Surname, Salary = Salary, Bonus = Bonus };
            return addNew;
        }

        public List<EmployeePerm> ReadAll()
        {
            List<EmployeePerm> ReadAll = new List<EmployeePerm>();
            for (int i = 0; i < employees.Count; i++)
            {
                ReadAll.Add(employees[i]);
            }
            return ReadAll;
        }

        EmployeePerm IEmployeeRepository<EmployeePerm>.ReadSingle(int i)
        {
            if (employees.Count() > i)
            {

                EmployeePerm ReadSingle = new EmployeePerm() { ID = employees[i].ID, FirstName = employees[i].FirstName, LastName = employees[i].LastName, Salary = employees[i].Salary, Bonus = employees[i].Bonus };
                return ReadSingle;
            }
            return null;
        }

        public EmployeePerm Update(int i, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeePerm employeePerm = new EmployeePerm() { ID = employees[i].ID, FirstName = FirstName, LastName = LastName, Salary = Salary, Bonus = Bonus };
            return employeePerm;
        }
    }
}
