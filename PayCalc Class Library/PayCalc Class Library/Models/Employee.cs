using System.ComponentModel.DataAnnotations;

namespace PayCalc.ClassLibrary.Models
{
    public abstract class Employee
    {

        [Key] public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Fullname => $"{FirstName} {LastName}";
    }
}
