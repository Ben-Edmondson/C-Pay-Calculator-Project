using PayCalc.ClassLibrary.Models;
namespace Web.Models
{
    public class PermanentEmployeeViewModel
    {
        public IEnumerable<PermanentEmployee> PermanentEmployees { get; }
        public PermanentEmployeeViewModel(IEnumerable<PermanentEmployee> permanentEmployees)
        {
            PermanentEmployees = permanentEmployees;
        }
    }
}
