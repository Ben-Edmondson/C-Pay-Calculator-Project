namespace PayCalc_Project.Models
{
    public class TemporaryEmployee : Employee
    {
        public decimal? DayRate { get; set; }
        public int? WeeksWorked { get; set; }
        public override string ToString()
        {
            return $"\nID: {ID} Name: {FirstName} {LastName} Day Rate: £{DayRate} Weeks Worked: {WeeksWorked}";
        }
    }
}
