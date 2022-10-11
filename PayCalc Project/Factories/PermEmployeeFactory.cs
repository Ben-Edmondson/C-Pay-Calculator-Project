using PayCalc_Project.Models;

namespace PayCalc_Project.Factories
{
    class PermEmployeeFactory
    {
        public static EmployeePerm CreateEmployee(string FirstName, string LastName, decimal? Salary, decimal? Bonus)
        {
            Random idGen = new Random();
            int id = idGen.Next(1111, 10000);
            EmployeePerm employee = new EmployeePerm() { ID = id, FirstName = FirstName, LastName = LastName, Salary = Salary, Bonus = Bonus };
            return employee;
        }
    }
}
