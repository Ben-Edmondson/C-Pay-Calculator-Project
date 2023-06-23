using PayCalc_Class_Library.dbContext;
using PayCalc_Project.Repos;
using PayCalc_Project.Models;

namespace PayCalc_Project.Repos.Persistent
{
    public class TemporaryEmployeeRepo : IEmployeeRepository<TemporaryEmployee>
    {

        private readonly MyDbContext _dbContext;
        public TemporaryEmployeeRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Delete(int id)
        {
            if (_dbContext.TemporaryEmployees.Any(e => e.ID == id))
            {
                TemporaryEmployee emp = _dbContext.TemporaryEmployees.Find(id);
                _dbContext.TemporaryEmployees.Remove(emp);
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
        public TemporaryEmployee Create(DateTime startDate, string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            TemporaryEmployee employee = new TemporaryEmployee() { StartDate = startDate, FirstName = firstName, LastName = lastName ,DayRate = dayRate, WeeksWorked = weeksWorked };
            _dbContext.TemporaryEmployees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }
        public List<TemporaryEmployee> ReadAll()
        {
            var employees = _dbContext.TemporaryEmployees.ToList();
            return employees;
        }
        public TemporaryEmployee? Read(int id)
        {
            if (_dbContext.TemporaryEmployees.Any(e => e.ID == id))
            {
                TemporaryEmployee readSingle = _dbContext.TemporaryEmployees.Find(id);
                return readSingle;
            }
            return null;
        }
        public bool Update(int id, string? firstName, string? lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked)
        {
            if (_dbContext.TemporaryEmployees.Any(e => e.ID == id))
            {
                TemporaryEmployee? employee = Read(id);

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
                if (bonus != null)
                {
                    employee.WeeksWorked = weeksWorked;
                }
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}