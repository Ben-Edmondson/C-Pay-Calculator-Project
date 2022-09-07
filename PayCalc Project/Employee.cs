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
        public Guid GuID {get; set;}
        public TypeOfEmployment EmploymentType;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary {get; set; }
        public decimal Bonus {get; set; } 
        public decimal DayRate { get; set; }
        public int WeeksWorked {get; set; }
        public string? FullName => $"{FirstName} {LastName}";
    }
}
