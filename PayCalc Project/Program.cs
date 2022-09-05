using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee joeBloggs = new Employee() { TypeOfEmployment = "Permanent", FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 };
            Employee johnSmith = new Employee() { TypeOfEmployment = "Permanent", FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 };
            Employee clareJones = new Employee() { TypeOfEmployment = "Temporary", FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 };
            Console.WriteLine($"User: {clareJones.FirstName} {clareJones.LastName} || Employment Type: {clareJones.TypeOfEmployment} || Annual Pay: {clareJones.TotalAnnualPay()} || Hourly Rate: {clareJones.doubleHourlyRate()}");
            Console.WriteLine($"User: {joeBloggs.FirstName} {joeBloggs.LastName} || Employment Type: {joeBloggs.TypeOfEmployment} || Annual Pay: {joeBloggs.TotalAnnualPay()} || Hourly Rate: {joeBloggs.doubleHourlyRate()}");
            Console.WriteLine($"User: {johnSmith.FirstName} {johnSmith.LastName} || Employment Type: {johnSmith.TypeOfEmployment} || Annual Pay: {johnSmith.TotalAnnualPay()} || Hourly Rate: {johnSmith.doubleHourlyRate()}");
            Console.ReadLine();
            //user can add employee to system, can get a list of them and data
        }
    }
}
