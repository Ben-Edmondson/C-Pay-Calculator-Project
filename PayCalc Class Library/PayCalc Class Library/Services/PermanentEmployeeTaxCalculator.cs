using PayCalc.ClassLibrary.Models;

namespace PayCalc.ClassLibrary.Services
{
    public class PermanentEmployeeTaxCalculator : ITaxCalculator<PermanentEmployee>
    {
        public decimal? TotalTaxPaid(PermanentEmployee employee)
        {
            var taxBands = new[]
            {
            new { Lower = 0m, Upper = 12570m, Rate = 0.0m },
            new { Lower = 12571m, Upper = 50270m, Rate = 0.2m },
            new { Lower = 50271m, Upper = 150000m, Rate = 0.4m },
            new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            };
            var salary = employee.Salary + employee.Bonus;

            var taxToBePaid = 0m;

            foreach (var band in taxBands)
            {
                if (salary > band.Lower)
                {
                    var taxableAtThisRate = Math.Min(band.Upper - band.Lower, (decimal)salary - band.Lower);
                    var taxThisBand = taxableAtThisRate * band.Rate;
                    taxToBePaid += taxThisBand;
                }
            }
            return Math.Round((decimal)taxToBePaid);
        }
    }
}
