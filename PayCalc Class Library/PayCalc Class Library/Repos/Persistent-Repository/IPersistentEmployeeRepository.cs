using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Class_Library.Repos.Persistent_Repository
{
    public interface IPersistentEmployeeRepository<T>
    {
        public void AddEmployee(T employee);
        public void UpdateEmployee(T employee);
        public void DeleteEmployee(T employee);
        public void GetEmployee(T employee);
        public void ReadAllEmployees(T employee);
    }
}
