using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { GuID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 });
            employees.Add(new Employee() { GuID = Guid.NewGuid() ,EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 });
            employees.Add(new Employee() { GuID = Guid.NewGuid() ,EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 });
            //user can add employee to system, can get a list of them and data
            Console.WriteLine("Add employee?");
            string? employeeAdd = Console.ReadLine();
            if (employeeAdd == "y")
            {
                Console.WriteLine("Is employee permanent or temporary?");
                string? EmployeeType = Console.ReadLine();
                Console.WriteLine("Enter a first name");
                string? FirstName = Console.ReadLine();
                Console.WriteLine("Please enter a last name");
                string? LastName = Console.ReadLine();
                if (EmployeeType.ToLower() == "permanent")
                {
                    Console.WriteLine("Please enter a salary");
                    decimal Salary = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter a bonus");
                    decimal Bonus = decimal.Parse(Console.ReadLine());
                    employees.Add(new Employee() {GuID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = FirstName, LastName = LastName, Salary = Salary, Bonus = Bonus });
                }
                else
                {
                    Console.WriteLine("Please enter a dayrate");
                    decimal DayRate = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter number of weeks worked per year");
                    int WeeksWorked = int.Parse(Console.ReadLine());
                    employees.Add(new Employee() { EmploymentType = TypeOfEmployment.Temporary, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked });

                }


            }
            //use this data to create new employee
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{employees[i].GuID.ToString()} {employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Annual Pay: {employees[i].TotalAnnualPay()} Hourly Pay: {employees[i].doubleHourlyRate()}");
            }
            Console.ReadLine();

        }

    }
}
