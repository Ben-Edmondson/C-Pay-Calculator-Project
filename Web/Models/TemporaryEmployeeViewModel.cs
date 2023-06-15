using PayCalc_Project.Models;

namespace Web.Models
{
    public class TemporaryEmployeeViewModel
    {
        public IEnumerable<TemporaryEmployee> TemporaryEmployees { get; }

        public TemporaryEmployeeViewModel(IEnumerable<TemporaryEmployee> temporaryEmployees)
        {
            
            TemporaryEmployees = temporaryEmployees;
        }
    }
}
