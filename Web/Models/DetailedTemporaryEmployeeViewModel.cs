using PayCalc_Project.Models;

namespace Web.Models
{
    public class DetailedTemporaryEmployeeViewModel
    {
        public TemporaryEmployeeSalary Employee { get; set; }
        public int WeeksWorkedSinceStartDate { get; set; }
        public DetailedTemporaryEmployeeViewModel(TemporaryEmployeeSalary employee, int weeksWorkedSinceStartDate)
        {
            Employee = employee;
            WeeksWorkedSinceStartDate = weeksWorkedSinceStartDate;
        }
    }
}
