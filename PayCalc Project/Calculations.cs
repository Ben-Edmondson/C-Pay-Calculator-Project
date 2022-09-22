using PayCalc_Project.Models;

namespace PayCalc_Project
{
    public class Calculations
    {
        public static decimal TotalAnnualPay(List<Employee> employees,int i)
        {

            if (employees[i].EmploymentType == TypeOfEmployment.Permanent)
            {
                return employees[i].Salary + employees[i].Bonus;
            }
            else
            {
                int days = 5;
                return Math.Round(employees[i].DayRate * (days * employees[i].WeeksWorked), 2);
            }

        }

        public static decimal HourlyPay(List<Employee> employees, int i)
        {
            if (employees[i].EmploymentType == TypeOfEmployment.Permanent)
            {

            }
            else
            {

            }
            return 0;
        }
    }
}
