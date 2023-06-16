using Microsoft.EntityFrameworkCore;
using PayCalc_Class_Library.Persistent_Repository;
using PayCalc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Class_Library.Repos.Persistent_Repository
{
    public class PersistentTemporaryEmployeeRepo : IPersistentEmployeeRepository<TemporaryEmployee>
    {
        private readonly MyDbContext _dbContext;
        public PersistentTemporaryEmployeeRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddEmployee(TemporaryEmployee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(TemporaryEmployee employee)
        {
            _dbContext.Remove(employee);
            _dbContext.SaveChanges();
        }

        public TemporaryEmployee GetEmployee(int id)
        {
            return _dbContext.Find<TemporaryEmployee>(id);
        }

        public IEnumerable<TemporaryEmployee> ReadAllEmployees()
        {
            return _dbContext.TemporaryEmployees.ToList();
        }

        public void UpdateEmployee(TemporaryEmployee employee)
        {
            _dbContext.Attach(employee);
            _dbContext.Entry(employee).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
