namespace PayCalc_Project.Models
{
    public class EmployeePerm : Employee
    {
        public decimal? Salary { get; set; }
        public decimal? Bonus { get; set; }
        public override string ToString()
        {
            return $"\nID: {ID} Name: {FirstName} {LastName} Salary: £{Salary} Bonus: £{Bonus}";
        }
    }
}
