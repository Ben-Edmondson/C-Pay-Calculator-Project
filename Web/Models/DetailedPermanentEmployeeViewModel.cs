using PayCalc.ClassLibrary.Models;

namespace Web.Models
{
    public class DetailedPermanentEmployeeViewModel
    {
        public PermanentEmployeeSalary Employee {get; set;}
        public int WeeksWorkedSinceStartDate { get; set;}
        public DetailedPermanentEmployeeViewModel(PermanentEmployeeSalary employee, int weeksWorkedSinceStartDate)
        {
            Employee = employee;
            WeeksWorkedSinceStartDate = weeksWorkedSinceStartDate;
        }
    }
}
