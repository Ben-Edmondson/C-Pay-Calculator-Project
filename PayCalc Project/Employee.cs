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
    }
}
