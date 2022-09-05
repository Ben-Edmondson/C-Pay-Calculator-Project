using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    public class Employee
    {
        public string fname = "Joe";
        public string lname = "Bloggs";
        public double aSalary = 20000;
        public double aBonus = 2000;

        public double TotalAnnualPay()
        {
            return aSalary + aBonus;
        }

        public double doubleHourlyRate()
        {
            int weeks = 52;
            int days = 5;
            int hours = 7;
            return Math.Round(aSalary / (days * hours) / weeks, 2);
        }
    }

    public class TempEmployee
    {
        public string fname = "Bob";
        public string lname = "Builder";
        public double dayRate = 300;
        public int days = 5;
        public int weeksPerYear = 30;
        public double TotalAnnualPay()
        {
            return Math.Round(dayRate * (days * weeksPerYear),2);
        }

        public double doubleHourlyRate()
        {
            int hours = 7;
            return Math.Round(dayRate / hours, 2);
        }


    }
}
