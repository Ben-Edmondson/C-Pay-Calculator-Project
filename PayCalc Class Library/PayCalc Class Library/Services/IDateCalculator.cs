namespace PayCalc_Project.Services
{
    public interface IDateCalculator<Employee>
    {
        public int WeeksWorkedSinceStartDate(Employee employee);
    }
}
