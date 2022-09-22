using PayCalc_Project.Models;

namespace PayCalc_Project
{
    class Calculations
    {
        public decimal? TotalAnnualPay(List<EmployeePerm> employees,int i)
        {
            decimal? Salary = employees[i].Salary;
            decimal? Bonus = employees[i].Bonus;
            decimal? Together = Salary + Bonus;
            return Together;
        }

    }
}
