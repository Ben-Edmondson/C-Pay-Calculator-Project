namespace PayCalc_Project
{
    public class Employee
    {
        public Guid ID {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
