namespace PayCalc_Project
{
    public class Employee
    {
        //enums
        public string? TypeOfEmployment;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary {get; set; }
        public decimal Bonus {get; set; } 
        public decimal DayRate { get; set; }
        public int WeeksWorked {get; set; }
        //properties
        
        public decimal TotalAnnualPay()
        {
            if(TypeOfEmployment == "Permanent")
            {
                return Salary + Bonus;
            }
            else
            {
                int days = 5;
                return Math.Round(DayRate * (days * WeeksWorked), 2);
            }

        }

        public decimal doubleHourlyRate()
        {
            if (TypeOfEmployment == "Permanent")
            {
                int weeks = 52;
                int days = 5;
                int hours = 7;
                return Math.Round(Salary / (days * hours) / weeks, 2);
            }
            else
            {
                int hours = 7;
                return Math.Round(DayRate / hours, 2);
            }
        }
    }
}
