using PayCalc_Project.Models;
namespace PayCalc_Project.Repository
{
    public class EmployeePermRepo : IEmployeeRepository<EmployeePerm>
    {
        public List<EmployeePerm> employees = new List<EmployeePerm>() {
            new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new EmployeePerm() { ID = Guid.NewGuid(), FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 },
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
        public EmployeePerm ReadSingle(int id)
        {
            if (employees.Count() > id)
            {
                EmployeePerm ReadSingle = new EmployeePerm() { ID = employees[id].ID, FirstName = employees[id].FirstName, LastName = employees[id].LastName, Salary = employees[id].Salary, Bonus = employees[id].Bonus };
                return ReadSingle;
            }
            return null;
        }
        public void Update(int index, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            employees[index].FirstName = FirstName;
            employees[index].LastName = LastName;
            employees[index].Salary = Salary;
            employees[index].Bonus = Bonus;
        }
    }
}
