using PayCalc_Project.Models;

namespace PayCalc_Project.Services
{
    public class DateCalculator : IDateCalculator<Employee>
    {
        public int WeeksWorkedSinceStartDate(Employee employee)
        {
            DateTime startDate = employee.StartDate;
            TimeSpan totalDays = DateTime.Today - startDate;
            int totalWeeks = (int)totalDays.TotalDays / 7;
            return totalWeeks;
        }
    }
}
