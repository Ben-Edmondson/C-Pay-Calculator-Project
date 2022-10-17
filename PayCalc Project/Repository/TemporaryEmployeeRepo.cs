using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class TemporaryEmployeeRepo : IEmployeeRepository<TemporaryEmployee>
    {
        static Random rnd = new Random();

        public List<TemporaryEmployee> employees = new List<TemporaryEmployee>()
        {
            new TemporaryEmployee(){ID = rnd.Next(1111,10000), FirstName = "Clare", LastName = "Jones",DayRate = 350,WeeksWorked = 40} 
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
            return true;
        }

        public List<TemporaryEmployee> ReadAll()
        {
            List<TemporaryEmployee> ReadAll = employees;
            return ReadAll;
        }

        public TemporaryEmployee? ReadSingle(int id)
        {
            TemporaryEmployee? ReadSingle = employees.Find(x => x.ID == id);
            return ReadSingle;
        }

        public bool Update(int id, string? FirstName, string? LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            foreach (TemporaryEmployee employee in employees)
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
                    if (DayRate != null)
                    {
                        employee.DayRate = DayRate;
                    }
                    if (WeeksWorked != null)
                    {
                        employee.WeeksWorked = WeeksWorked;
                    }
                    return true;
                }
            }
            return false;
        }

        public TemporaryEmployee Create(string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            Random idGen = new Random();
            int id = idGen.Next(1111, 10000);
            TemporaryEmployee employee = new TemporaryEmployee() { ID = id, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked };
            return employee;
        }

        public void AddEmployee(TemporaryEmployee employee)
        {
            employees.Add(employee);
        }
    }
}
