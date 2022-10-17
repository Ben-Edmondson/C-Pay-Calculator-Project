using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class TemporaryEmployeeRepo : IEmployeeRepository<TemporaryEmployee>
    {
        static Random rnd = new Random();

        private List<TemporaryEmployee> employees = new List<TemporaryEmployee>()
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

        public bool Update(int id, string? firstName, string? lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            foreach (TemporaryEmployee employee in employees)
            {
                if (employee.ID == id)
                {
                    if (String.IsNullOrEmpty(firstName) == false)
                    {
                        employee.FirstName = firstName;
                    }
                    if (String.IsNullOrEmpty(lastName) == false)
                    {
                        employee.LastName = lastName;
                    }
                    if (dayRate != null)
                    {
                        employee.DayRate = dayRate;
                    }
                    if (weeksWorked != null)
                    {
                        employee.WeeksWorked = weeksWorked;
                    }
                    return true;
                }
            }
            return false;
        }

        public TemporaryEmployee Create(string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            Random idGen = new Random();
            int id = idGen.Next(1111, 10000);
            TemporaryEmployee employee = new TemporaryEmployee() { ID = id, FirstName = firstName, LastName = lastName, DayRate = dayRate, WeeksWorked = weeksWorked };
            employees.Add(employee);
            return employee;
        }
    }
}
