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
            Employee joeBloggs = new Employee() { typeOfEmployment = "Permanent", fname = "Joe", lname = "Bloggs", aSalary = 40000, aBonus = 5000 };
            Employee johnSmith = new Employee() { typeOfEmployment = "Permanent", fname = "John", lname = "Smith", aSalary = 45000, aBonus = 2500 };
            Employee clareJones = new Employee() { typeOfEmployment = "Temporary", fname = "Clare", lname = "Jones", dayRate = 350, weeksWorked = 40 };
            Console.WriteLine($"User: {clareJones.fname} {clareJones.lname} Employment Type: {clareJones.typeOfEmployment} Annual Pay: {clareJones.TotalAnnualPay()} Hourly Rate: {clareJones.doubleHourlyRate()}");
            Console.WriteLine($"User: {joeBloggs.fname} {joeBloggs.lname} Employment Type: {joeBloggs.typeOfEmployment} Annual Pay: {joeBloggs.TotalAnnualPay()} Hourly Rate: {joeBloggs.doubleHourlyRate()}");
            Console.WriteLine($"User: {johnSmith.fname} {johnSmith.lname} Employment Type: {johnSmith.typeOfEmployment} Annual Pay: {johnSmith.TotalAnnualPay()} Hourly Rate: {johnSmith.doubleHourlyRate()}");
            Console.ReadLine();
        }
    }
}
