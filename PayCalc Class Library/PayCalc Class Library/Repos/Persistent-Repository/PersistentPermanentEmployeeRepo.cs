using PayCalc_Class_Library.Persistent_Repository;
using PayCalc_Class_Library.Repos;
using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class PersistentPermanentEmployeeRepo : IEmployeeRepository<PermanentEmployee>
    {

        private readonly MyDbContext _dbContext;
        public PersistentPermanentEmployeeRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Delete(int id)
        {
            if (_dbContext.PermanentEmployees.Any(e => e.ID == id))
            {
                PermanentEmployee employee = _dbContext.PermanentEmployees.Find(id);
                _dbContext.PermanentEmployees.Remove(employee);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool RemoveAll()
        {
            //This was implemented for usage ONLY in a volatile setting. Do not implement this.
            return false;
        }
        public PermanentEmployee Create(DateTime startDate, string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            PermanentEmployee employee = new PermanentEmployee() { StartDate = startDate, FirstName = firstName, LastName = lastName, Salary = salary, Bonus = bonus };
            _dbContext.PermanentEmployees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }
        public List<PermanentEmployee> ReadAll()
        {
            var employees = _dbContext.PermanentEmployees.ToList();
            return employees;
        }
        public PermanentEmployee? Read(int id)
        {
            if (_dbContext.PermanentEmployees.Any(e => e.ID == id))
            {
                PermanentEmployee readSingle = _dbContext.PermanentEmployees.Find(id);
                return readSingle;
            }
            return null;
        }
        public bool Update(int id, string? firstName, string? lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            if (_dbContext.PermanentEmployees.Any(e => e.ID == id))
            {
                PermanentEmployee? employee = Read(id);

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
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}