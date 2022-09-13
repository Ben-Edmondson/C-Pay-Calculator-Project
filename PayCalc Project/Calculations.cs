namespace PayCalc_Project
{
    public class Calculations
    { 
        public static decimal TotalAnnualPay(List<Employee>employees, int i)
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

        public static decimal doubleHourlyRate(List<Employee> employees, int i)
        {
            if (employees[i].EmploymentType == TypeOfEmployment.Permanent)
            {
                int weeks = 52;
                int days = 5;
                int hours = 7;
                return Math.Round(employees[i].Salary / (days * hours) / weeks, 2);
            }
            else
            {
                int hours = 7;
                return Math.Round(employees[i].DayRate / hours, 2);
            }
        }
    }
}
