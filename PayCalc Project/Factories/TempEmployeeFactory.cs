using PayCalc_Project.Models;

namespace PayCalc_Project.Factories
{
    class TempEmployeeFactory
    {
        public static EmployeeTemp CreateEmployee(string FirstName, string LastName, decimal? DayRate, int? WeeksWorked)
        {
            Random idGen = new Random();
            int id = idGen.Next(1111, 10000);
            EmployeeTemp employee = new EmployeeTemp() { ID = id, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked};
            return employee;
        }
    }
}
