using PayCalc_Project.Models;

namespace PayCalc_Project.Services
{
    public class Calculations
    {
        public static decimal? TotalAnnualPayPerm(List<EmployeePerm> employees, int i)
        {
            decimal? Salary = employees[i].Salary;
            decimal? Bonus = employees[i].Bonus;
            decimal? Together = Salary + Bonus;
            return Together;
        }
        public static decimal? TotalAnnualPayTemp(List<EmployeeTemp> employees, int i)
        {
            int? days = 5;
            decimal? DayRate = employees[i].DayRate;
            int? WeeksWorked = employees[i].WeeksWorked;
           
            decimal? Total = Math.Round((decimal)(DayRate * (days * WeeksWorked)), 2);
            return Total;
        }

    }
}
