namespace PayCalc_Project.Services
{
    public interface ICalculations<T>
    {
        public decimal? TotalTaxPaid(T employees);
    }
}
