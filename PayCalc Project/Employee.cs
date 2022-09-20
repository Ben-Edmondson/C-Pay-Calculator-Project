namespace PayCalc_Project
{
    public enum TypeOfEmployment
    {
        Permanent,
        Temporary
    }
    public class Employee
    {
        public Guid ID {get; set;}
        public TypeOfEmployment EmploymentType;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
