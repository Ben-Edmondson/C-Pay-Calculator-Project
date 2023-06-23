using PayCalc_Project.Models;

namespace PayCalc_Project.Repos.Volatile
{
    public class TemporaryEmployeeRepo : IEmployeeRepository<TemporaryEmployee>
    {
        private static Random rnd = new Random();

        private List<TemporaryEmployee> employees = new List<TemporaryEmployee>()
        {
            new TemporaryEmployee() { ID = rnd.Next(1111, 10000), FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40, StartDate = new DateTime(2003,1,1) }
        };
        public TemporaryEmployeeRepo()
        {

        }
        public TemporaryEmployeeRepo(IEnumerable<TemporaryEmployee> temp)
        {
            employees.AddRange(temp);
        }
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
            return employees;
        }
        public TemporaryEmployee? Read(int id)
        {
            var readSingle = employees.Find(x => x.ID == id);
            return readSingle;
        }
        public bool Update(int id, string? firstName, string? lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            foreach (var employee in employees)
            {
                if (employee.ID == id)
                {
                    if (string.IsNullOrEmpty(firstName) == false)
                    {
                        employee.FirstName = firstName;
                    }
                    if (string.IsNullOrEmpty(lastName) == false)
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
        public TemporaryEmployee Create(DateTime startDate, string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            TemporaryEmployee employee = new TemporaryEmployee() { StartDate = startDate, ID = rnd.Next(1111, 10000), FirstName = firstName, LastName = lastName, DayRate = dayRate, WeeksWorked = weeksWorked };
            employees.Add(employee);
            return employee;
        }
    }
}
