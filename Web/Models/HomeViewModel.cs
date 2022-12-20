using PayCalc_Project.Models;

namespace Web.Models
{
    public class HomeViewModel
    { 
        public IEnumerable<PermanentEmployee> PermanentEmployees { get;}
        public List<TemporaryEmployeeSalary>? TemporaryEmployees { get;}

        public HomeViewModel(IEnumerable<PermanentEmployee>? permanentEmployees)
        {
            PermanentEmployees = permanentEmployees;
        }
    }
}
