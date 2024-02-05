namespace PayCalc.ClassLibrary.Services
{
    public interface ITaxCalculator<T>
    {
        public decimal? TotalTaxPaid(T employees);
    }
}
