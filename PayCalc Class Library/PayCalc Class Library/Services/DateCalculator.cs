﻿using PayCalc_Project.Models;

namespace PayCalc_Project.Services
{
    public class DateCalculator : IDateCalculator<Employee>
    {
        public int WeeksWorkedSinceStartDate(Employee employee)
        {
            DateTime startDate = employee.StartDate;
            TimeSpan totalDays;
            if(employee.EndDate == null)
            {
                totalDays = DateTime.Today - startDate;
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
