namespace PayCalc_Project.Services
{
    public interface ITaxCalculator<T>
    {
        public decimal? TotalTaxPaid(T employees);
    }
}
