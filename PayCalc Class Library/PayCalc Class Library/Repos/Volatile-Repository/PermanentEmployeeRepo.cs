using PayCalc.ClassLibrary.Models;

namespace PayCalc.ClassLibrary.Repos.Volatile
{
    public class PermanentEmployeeRepo : IEmployeeRepository<PermanentEmployee>
    {
        private static Random rnd = new Random();

        private List<PermanentEmployee> employees = new List<PermanentEmployee>()
        {
            new PermanentEmployee(){ ID = rnd.Next(1111, 10000), FirstName = "Joe", LastName = "Bloggs", Salary = 40000.00m, Bonus = 5000.00m, StartDate = new DateTime(2000,8,3) },
            new PermanentEmployee(){ ID = rnd.Next(1111, 10000), FirstName = "John", LastName = "Smith", Salary = 45000.00m, Bonus = 2500.00m, StartDate = new DateTime(2000,10,3) }
        };

        public PermanentEmployeeRepo()
        {

        }
        public PermanentEmployeeRepo(IEnumerable<PermanentEmployee> temp)
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
        public PermanentEmployee Create(DateTime startDate, string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            PermanentEmployee employee = new PermanentEmployee() { StartDate = startDate, ID = rnd.Next(1111, 10000), FirstName = firstName, LastName = lastName, Salary = salary, Bonus = bonus };
            employees.Add(employee);
            return employee;
        }
        public List<PermanentEmployee> ReadAll()
        {
            return employees;
        }
        public PermanentEmployee? Read(int id)
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
                    if (salary != null)
                    {
                        employee.Salary = salary;
                    }
                    if (bonus != null)
                    {
                        employee.Bonus = bonus;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
