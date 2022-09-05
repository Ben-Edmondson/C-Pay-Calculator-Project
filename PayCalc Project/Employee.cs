using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    class Employee
    {
        public string? fName;
        public string? lName;
        public double aSalary;
        public double aBonus;

        public Employee(string firstName, string lastName, double annualSalary, double annualBonus)
        {
            fName = firstName;
            lName = lastName;
            aSalary = annualSalary;
            aBonus = annualBonus;
        }

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
