using PayCalc.ClassLibrary.Models;

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
