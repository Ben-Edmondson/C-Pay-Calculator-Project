using PayCalc_Project.Factories;
using PayCalc_Project.Models;
namespace PayCalc_Project.Repository
{
    public class EmployeePermRepo : IEmployeeRepository<EmployeePerm>
    {
        public List<EmployeePerm> employees = new List<EmployeePerm>() {
            new EmployeePerm() {ID = 1112, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new EmployeePerm() {ID = 1113, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 },
        };
        public bool Delete(int id)
        {   
            if (employees.Exists(x => x.ID == id) ==true)
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
        public EmployeePerm AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeePerm addNew = PermEmployeeFactory.CreateEmployee(FirstName, Surname, Salary, Bonus);
            return addNew;
        }
        public List<EmployeePerm> ReadAll()
        {
            List<EmployeePerm> ReadAll = employees;
            return ReadAll;
        }
        public EmployeePerm? ReadSingle(int id)
        {
            EmployeePerm? ReadSingle = employees.Find(x => x.ID == id);
            return ReadSingle;
        }
        public bool Update(int id, string? FirstName, string? LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            foreach (EmployeePerm employee in employees)
            {
                if (employee.ID == id)
                {
                    if (String.IsNullOrEmpty(FirstName) == false)
                    {
                        employee.FirstName = FirstName;
                    }
                    if (String.IsNullOrEmpty(LastName) == false)
                    {
                        employee.LastName = LastName;
                    }
                    if (Salary != null)
                    {
                        employee.Salary = Salary;
                    }
                    if (Bonus != null)
                    { 
                        employee.Bonus = Bonus;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
