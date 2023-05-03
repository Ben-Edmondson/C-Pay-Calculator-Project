namespace PayCalc_Project.Services
{
    public interface IDateCalculation<Employee>
    {
        public int WeeksWorkedSinceStartDate(Employee employee);
    }
}
