namespace PayCalc_Project
{
    public class Employee
    {
        public string? typeOfEmployment;
        public string? fname;
        public string? lname;
        public double aSalary;
        public double aBonus;
        public double dayRate;
        public int weeksWorked;

        public double TotalAnnualPay()
        {
            if(typeOfEmployment == "Permanent")
            {
                return aSalary + aBonus;
            }
            else
            {
                int days = 5;
                return Math.Round(dayRate * (days * weeksWorked), 2);
            }

        }

        public double doubleHourlyRate()
        {
            if (typeOfEmployment == "Permanent")
            {
                int weeks = 52;
                int days = 5;
                int hours = 7;
                return Math.Round(aSalary / (days * hours) / weeks, 2);
            }
            else
            {
                int hours = 7;
                return Math.Round(dayRate / hours, 2);
            }
        }
    }
}
