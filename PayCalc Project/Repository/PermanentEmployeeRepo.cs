using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class PermanentEmployeeRepo : IEmployeeRepository<PermanentEmployee>
    {
        private Random rnd = new Random();

        private List<PermanentEmployee> employees = new List<PermanentEmployee>();

        public PermanentEmployeeRepo()
        {
            employees.Add(new PermanentEmployee { ID = rnd.Next(1111, 10000), FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 });
            employees.Add(new PermanentEmployee { ID = rnd.Next(1111, 10000), FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 });
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
        public PermanentEmployee Create(string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {

            PermanentEmployee employee = new PermanentEmployee() { ID = rnd.Next(1111, 10000), FirstName = firstName, LastName = lastName, Salary = salary, Bonus = bonus };
            employees.Add(employee);
            return employee;
        }
        public List<PermanentEmployee> ReadAll()
        {
            List<PermanentEmployee> readAll = employees;
            return readAll;
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
                    if (String.IsNullOrEmpty(firstName) == false)
                    {
                        employee.FirstName = firstName;
                    }
                    if (String.IsNullOrEmpty(lastName) == false)
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
