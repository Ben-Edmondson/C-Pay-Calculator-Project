using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 });
            employees.Add(new Employee() { ID = Guid.NewGuid() ,EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 });
            employees.Add(new Employee() { ID = Guid.NewGuid() ,EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 });
           
            Console.WriteLine("Add employee?");
            string? employeeAdd = Console.ReadLine();
            if (employeeAdd == "y")
            {
                Console.WriteLine("Is employee permanent or temporary?");
                string? EmployeeType = Console.ReadLine();
                string FirstName = Input.FirstNameInput();
                string LastName = Input.LastNameInput();
                if (EmployeeType.ToLower() == "permanent")
                {
                    decimal Salary = Input.SalaryInput();
                    decimal Bonus = Input.BonusInput();
                    CRUD.AddPermanentEmployee(employees, FirstName, LastName, Salary, Bonus);
                }
                else
                {
                    decimal DayRate = Input.DayRate();
                    int WeeksWorked = Input.WeeksWorked();
                    CRUD.AddTempEmployee(employees, FirstName, LastName, DayRate, WeeksWorked);
                 }
            }
            CRUD.Read(employees);
            CRUD.ReadSingle(employees, 2);
        }

    }
}
