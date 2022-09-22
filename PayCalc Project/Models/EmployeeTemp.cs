namespace PayCalc_Project.Models
{
    class EmployeeTemp : Employee
    {
        public decimal? DayRate { get; set; }
        public int? WeeksWorked { get; set; }
    }
}
