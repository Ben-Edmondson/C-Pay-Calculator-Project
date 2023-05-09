using PayCalc_Project.Models;
namespace PayCalc_Project.Services
{
    public class TemporaryEmployeeTaxCaculator : ITaxCalculator<TemporaryEmployee>
    {
        public decimal? TotalTaxPaid(TemporaryEmployee employee)
        {
            var days = 5;
            var dayRate = employee.DayRate;
            var weeksWorked = employee.WeeksWorked;
            var totalPay = dayRate * (days * weeksWorked);
            var taxBands = new[]
            {
            new { Lower = 0m, Upper = 12570m, Rate = 0.0m },
            new { Lower = 12571m, Upper = 50270m, Rate = 0.2m },
            new { Lower = 50271m, Upper = 150000m, Rate = 0.4m },
            new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            };
            var taxToBePaid = 0m;

            foreach (var band in taxBands)
            {
                if (totalPay > band.Lower)
                {
                    var taxableAtThisRate = Math.Min(band.Upper - band.Lower, (decimal)totalPay - band.Lower);
                    var taxThisBand = taxableAtThisRate * band.Rate;
                    taxToBePaid += taxThisBand;
                }
            }
            return Math.Round((decimal)taxToBePaid);
        }
    }
}
