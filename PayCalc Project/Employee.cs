namespace PayCalc_Project
{
    public enum TypeOfEmployment
    {
        Permanent,
        Temporary,
        Contractor
    }
    public class Employee
    {
        public TypeOfEmployment EmploymentType;
        public string? FirstName
        {
            get => FirstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name must not be blank");
                FirstName = value;
            }
        }
        public string? LastName
        {
            get => LastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name must not be blank");
                LastName = value;
            }
        }
        public decimal Salary {get; set; }
        public decimal Bonus {get; set; } 
        public decimal DayRate { get; set; }
        public int WeeksWorked {get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        
        public decimal TotalAnnualPay()
        {
            if(EmploymentType == TypeOfEmployment.Permanent)
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
            if (EmploymentType == TypeOfEmployment.Permanent)
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
