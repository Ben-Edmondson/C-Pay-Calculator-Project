using System.ComponentModel.DataAnnotations.Schema;

namespace PayCalc_Project.Models
{
    public class PermanentEmployee : Employee
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salary { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Bonus { get; set; }
        public override string ToString()
        {
            return $"\nID: {ID} Name: {FirstName} {LastName} Salary: £{Salary} Bonus: £{Bonus}";
        }
    }
}
