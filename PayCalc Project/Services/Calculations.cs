using PayCalc_Project.Models;

namespace PayCalc_Project.Services
{
    public class Calculations
    {
        public static decimal? TotalAnnualPayPerm(List<EmployeePerm> employees, int i)
        {
            var taxBands = new[]
            {
            new { Lower = 0m, Upper = 12570m, Rate = 0.0m },
            new { Lower = 12571m, Upper = 50270m, Rate = 0.2m },
            new { Lower = 50271m, Upper = 150000m, Rate = 0.4m },
            new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            };

            var salary = employees[i].Salary;

            decimal? taxToBePaid = 0m;

            foreach (var band in taxBands)
            {
                if (salary > band.Lower)
                {
                    decimal? taxableAtThisRate = Math.Min(band.Upper - band.Lower, (byte)salary - band.Lower);
                    decimal? taxThisBand = taxableAtThisRate * band.Rate;
                    taxToBePaid += taxThisBand;
                }
            }
            return salary - taxToBePaid;
        }
        public static decimal? TotalAnnualPayTemp(List<EmployeeTemp> employees, int i)
        {
            int? days = 5;
            decimal? DayRate = employees[i].DayRate;
            int? WeeksWorked = employees[i].WeeksWorked;
            decimal? Total = Math.Round((decimal)(DayRate * (days * WeeksWorked)), 2);
            var taxBands = new[]
            {
            new { Lower = 0m, Upper = 12570m, Rate = 0.0m },
            new { Lower = 12571m, Upper = 50270m, Rate = 0.2m },
            new { Lower = 50271m, Upper = 150000m, Rate = 0.4m },
            new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            };

            var salary = Total;

            decimal? taxToBePaid = 0m;

            foreach (var band in taxBands)
            {
                if (salary > band.Lower)
                {
                    decimal? taxableAtThisRate = Math.Min(band.Upper - band.Lower, (byte)salary - band.Lower);
                    decimal? taxThisBand = taxableAtThisRate * band.Rate;
                    taxToBePaid += taxThisBand;
                }
            }
            return salary - taxToBePaid;
        }

    }
}
