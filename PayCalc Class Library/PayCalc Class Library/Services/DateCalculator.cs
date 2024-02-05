using PayCalc.ClassLibrary.Models;

namespace PayCalc.ClassLibrary.Services
{
    public class DateCalculator : IDateCalculator<Employee>
    {
        public int WeeksWorkedSinceStartDate(Employee employee, DateTime currentDate)
        {
            DateTime startDate = employee.StartDate;
            TimeSpan totalDays;
            if(employee.EndDate == null)
            {
                totalDays = currentDate - startDate;
            }
            else
            {
                DateTime? endDate = employee.EndDate;
                totalDays = (DateTime)endDate - startDate;
            }
            int totalWeeks = (int)totalDays.TotalDays / 7;
            return totalWeeks;
        }
    }
}
