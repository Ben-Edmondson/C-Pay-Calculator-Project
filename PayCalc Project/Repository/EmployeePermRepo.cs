using PayCalc_Project.Models;
namespace PayCalc_Project.Repository
{
    public class EmployeePermRepo : IEmployeeRepository<EmployeePerm>
    {
        static Random rnd = new Random();

        public List<EmployeePerm> employees = new List<EmployeePerm>()
        {
            new EmployeePerm(){ID = rnd.Next(1111,10000),FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000},
            new EmployeePerm(){ID = rnd.Next(1111,10000),FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }
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
            return true;
        }
        public EmployeePerm Create(string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            Random idGen = new Random();
            int id = idGen.Next(1111, 10000);
            EmployeePerm employee = new EmployeePerm() { ID = id, FirstName = FirstName, LastName = LastName, Salary = Salary, Bonus = Bonus };
            return employee;
        }
        public void AddEmployee(EmployeePerm employee)
        {
            employees.Add(employee);
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
