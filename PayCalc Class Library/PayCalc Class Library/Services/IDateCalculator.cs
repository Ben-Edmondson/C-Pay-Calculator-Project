namespace PayCalc.ClassLibrary.Services
{
    public interface IDateCalculator<Employee>
    {
        public int WeeksWorkedSinceStartDate(Employee employee, DateTime endDate);
    }
}
