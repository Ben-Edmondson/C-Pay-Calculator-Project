using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    class Employee
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
            return aSalary / (days * hours) / weeks;
        }
    }
}
