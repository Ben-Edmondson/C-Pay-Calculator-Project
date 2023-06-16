using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Class_Library.Repos.Persistent_Repository
{
    public interface IPersistentEmployeeRepository<T> where T : class
    {
        public void AddEmployee(T employee);
        public void UpdateEmployee(T employee);
        public bool DeleteEmployee(T employee);
        public T GetEmployee(int id);
        public IEnumerable<T> ReadAllEmployees();
    }
}
