namespace PayCalc_Project.Models
{
    public abstract class Employee
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
