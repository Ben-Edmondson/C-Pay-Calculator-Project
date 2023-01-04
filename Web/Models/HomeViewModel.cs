using PayCalc_Project.Models;

namespace Web.Models
{
    public class HomeViewModel
    { 
        public IEnumerable<PermanentEmployee>? PermanentEmployees { get;}
        public IEnumerable<TemporaryEmployee>? TemporaryEmployees { get;}
        public HomeViewModel(IEnumerable<PermanentEmployee>? permanentEmployees, IEnumerable<TemporaryEmployee> temporaryEmployees)
        {
            PermanentEmployees = permanentEmployees;
            TemporaryEmployees = temporaryEmployees;
        }
    }
}
