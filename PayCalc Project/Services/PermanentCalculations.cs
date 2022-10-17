using PayCalc_Project.Models;
using PayCalc_Project.Repository;

namespace PayCalc_Project.Services
{
    class PermanentCalculations : ICalculations<PermanentEmployee>
    {
        public decimal? TotalAnnualPay(List<PermanentEmployee> employees, int id)
        {
            foreach (PermanentEmployee employee in employees)
            {
                if (employee.ID == id)
                {

                    var taxBands = new[]
                    {
            new { Lower = 0m, Upper = 12570m, Rate = 0.0m },
            new { Lower = 12571m, Upper = 50270m, Rate = 0.2m },
            new { Lower = 50271m, Upper = 150000m, Rate = 0.4m },
            new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            };
                    var salary = employees[id].Salary + employees[id].Bonus;

                    decimal? taxToBePaid = 0m;

                    foreach (var band in taxBands)
                    {
                        if (salary > band.Lower)
                        {
                            decimal? taxableAtThisRate = Math.Min(band.Upper - band.Lower, (decimal)salary - band.Lower);
                            decimal? taxThisBand = taxableAtThisRate * band.Rate;
                            taxToBePaid += taxThisBand;
                        }
                    }
                    return taxToBePaid;
                }
            }
            return null;
        }
    }
}
