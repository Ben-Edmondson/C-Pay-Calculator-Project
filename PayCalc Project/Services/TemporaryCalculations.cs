﻿using PayCalc_Project.Models;
namespace PayCalc_Project.Services
{
    public class TemporaryCalculations : ICalculations<TemporaryEmployee>
    {
        public decimal? TotalAnnualPay(TemporaryEmployee employee)
        {
                    int? days = 5;
            decimal? DayRate = employee.DayRate;
                    int? WeeksWorked = employee.WeeksWorked;
                    decimal? TotalPay = DayRate * (days * WeeksWorked);
                    var taxBands = new[]
                    {
            new { Lower = 0m, Upper = 12570m, Rate = 0.0m },
            new { Lower = 12571m, Upper = 50270m, Rate = 0.2m },
            new { Lower = 50271m, Upper = 150000m, Rate = 0.4m },
            new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            };
                    decimal? taxToBePaid = 0m;

                    foreach (var band in taxBands)
                    {
                        if (TotalPay > band.Lower)
                        {
                            decimal? taxableAtThisRate = Math.Min(band.Upper - band.Lower, (decimal)TotalPay - band.Lower);
                            decimal? taxThisBand = taxableAtThisRate * band.Rate;
                            taxToBePaid += taxThisBand;
                        }
                    }
                    return taxToBePaid;
                }
        }
    }
}
