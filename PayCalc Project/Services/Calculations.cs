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

            int Basic = 20;
            int Higher = 40;
            int Additional = 45;
            decimal? TaxedIncome = Together - 12570;
            if (Together > 150000)
            {
                decimal? AdditionalRate = Together - 150000;
                decimal? ResultAdditional = (AdditionalRate / 100) * 45;
                decimal? HigherRate = 150000 - 50271;
                decimal? ResultHigher = (HigherRate / 100) * 40;
                decimal? BasicRate = 37701;
                decimal? ResultBasic = (BasicRate / 100) * 20;
                decimal? TotalTax = ResultAdditional + ResultHigher + ResultBasic;
                return TotalTax;
            }
            else if (Together > 50271)
            {
                decimal? HigherRate = Together - 50271;
                decimal? ResultHigher = (HigherRate / 100) * 40;
                decimal? BasicRate = 50270 - 12570;
                decimal? ResultBasic = (BasicRate / 100) * 20;
                decimal? TotalTax = ResultBasic + ResultHigher;
                return TotalTax;
            }
            else
            {
                decimal? BasicRate = Together - 12570;
                decimal? ResultBasic = (BasicRate / 100) * 20;
                decimal? TotalTax = ResultBasic;
                return TotalTax;
            }
        }
        public static decimal? TotalAnnualPayTemp(List<EmployeeTemp> employees, int i)
        {
            int? days = 5;
            decimal? DayRate = employees[i].DayRate;
            int? WeeksWorked = employees[i].WeeksWorked;
           
            decimal? Total = Math.Round((decimal)(DayRate * (days * WeeksWorked)), 2);
            if (Total > 150000)
            {
                decimal? AdditionalRate = Total - 150000;
                decimal? ResultAdditional = (AdditionalRate / 100) * 45;
                decimal? HigherRate = 150000 - 50271;
                decimal? ResultHigher = (HigherRate / 100) * 40;
                decimal? BasicRate = 37701;
                decimal? ResultBasic = (BasicRate / 100) * 20;
                decimal? TotalTax = ResultAdditional + ResultHigher + ResultBasic;
                return TotalTax;
            }
            else if (Total > 50271)
            {
                decimal? HigherRate = Total - 50271;
                decimal? ResultHigher = (HigherRate / 100) * 40;
                decimal? BasicRate = 50270 - 12570;
                decimal? ResultBasic = (BasicRate / 100) * 20;
                decimal? TotalTax = ResultBasic + ResultHigher;
                return TotalTax;
            }
            else
            {
                decimal? BasicRate = Total - 12570;
                decimal? ResultBasic = (BasicRate / 100) * 20;
                decimal? TotalTax = ResultBasic;
                return TotalTax;
            }
        }

    }
}
