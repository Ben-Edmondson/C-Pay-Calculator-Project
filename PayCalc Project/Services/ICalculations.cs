namespace PayCalc_Project.Services
{   
    public interface ICalculations<T>
    {
        public decimal? TotalAnnualPay(List<T> employees,int index);

    }
}
