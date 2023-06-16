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
    public class PersistentPermanentEmployeeRepo : IPersistentEmployeeRepository<PermanentEmployee>
    {
        private readonly MyDbContext _dbContext;
        public PersistentPermanentEmployeeRepo(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public void AddEmployee(PermanentEmployee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public bool DeleteEmployee(PermanentEmployee employee)
        {
            _dbContext.Remove(employee);
            _dbContext.SaveChanges();
            return true;
        }

        public PermanentEmployee GetEmployee(int id)
        {
            return _dbContext.Find<PermanentEmployee>(id);  
        }

        public IEnumerable<PermanentEmployee> ReadAllEmployees()
        {
            return _dbContext.PermanentEmployees.ToList();
        }

        public void UpdateEmployee(PermanentEmployee employee)
        {
            _dbContext.Attach(employee);
            _dbContext.Entry(employee).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
