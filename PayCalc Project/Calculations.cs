namespace PayCalc_Project
{
    public class Calculations
    { 
        public static decimal TotalAnnualPay(List<Employee>employees, int i)
        {
            List<Employee> employeeList = employees;
            if (employeeList[i].EmploymentType == TypeOfEmployment.Permanent)
            {
                return employeeList[i].Salary + employeeList[i].Bonus;
            }
            else
            {
                int days = 5;
                return Math.Round(employeeList[i].DayRate * (days * employeeList[i].WeeksWorked), 2);
            }

        }

        public static decimal doubleHourlyRate(List<Employee> employees, int i)
        {
            List<Employee> employeeList = employees;
            if (employeeList[i].EmploymentType == TypeOfEmployment.Permanent)
            {
                int weeks = 52;
                int days = 5;
                int hours = 7;
                return Math.Round(employeeList[i].Salary / (days * hours) / weeks, 2);
            }
            else
            {
                int hours = 7;
                return Math.Round(employeeList[i].DayRate / hours, 2);
            }
        }
    }
}
