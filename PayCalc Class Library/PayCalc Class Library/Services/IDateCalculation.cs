namespace PayCalc_Project.Services
{
    public interface IDateCalculation<T>
    {
        public int WeeksWorkedSinceStartDate(T employee);
    }
}
