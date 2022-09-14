namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = CRUD.EmployeesInit();
            Console.WriteLine("Add employee?");
            string? employeeAdd = Console.ReadLine();
            if (employeeAdd == "y")
            {
                string EmployeeType = TypeOfEmploymentString();
                string FirstName = FirstNameInput();
                string LastName = LastNameInput();
                if (EmployeeType.ToLower() == "permanent")
                {
                    decimal Salary = SalaryInput();
                    decimal Bonus = BonusInput();
                    CRUD.AddPermanentEmployee(employees, FirstName, LastName, Salary, Bonus);
                }
                else
                {
                    decimal DayRate = DayRateInput();
                    int WeeksWorked = WeeksWorkedInput();
                    CRUD.AddTempEmployee(employees, FirstName, LastName, DayRate, WeeksWorked);
                 }
            }
            CRUD.Read(employees);
            CRUD.ReadSingle(employees, 2);
        }

        public static string TypeOfEmploymentString()
        {
            Console.WriteLine("Is employee permanent or temporary?");
            string? EmployeeType = Console.ReadLine();
            if (EmployeeType == null || EmployeeType == "")
            {
                do
                {
                    Console.WriteLine("Please enter a valid employment type");
                    EmployeeType = Console.ReadLine();
                } while (EmployeeType == null || EmployeeType == "");
            }
            return EmployeeType;
        }
        public static string FirstNameInput()
        {
            Console.WriteLine("Enter a first name");
            string? FirstName = Console.ReadLine();
            if (FirstName == "" || FirstName == null)
            {
                do
                {
                    Console.WriteLine("Please enter a valid First Name!");
                    FirstName = Console.ReadLine();
                } while (FirstName == "" || FirstName == null);
            }
            return FirstName;
        }
        public static string LastNameInput()
        {
            Console.WriteLine("Please enter a last name");
            string? LastName = Console.ReadLine();
            if (LastName == "" || LastName == null)
            {
                do
                {
                    Console.WriteLine("Please enter a valid Last Name!");
                    LastName = Console.ReadLine();
                } while (LastName == "" || LastName == null);
            }
            return LastName;
        }
        public static decimal SalaryInput()
        {
            Console.WriteLine("Please enter a salary");
            string? Salary = Console.ReadLine();
            if (decimal.TryParse(Salary, out decimal DecSalary))
            {
                return DecSalary;
            }
            else
            {
                bool x = true;
                do
                {
                    Console.WriteLine("Please enter a valid salary");
                    Salary = Console.ReadLine();
                    if (decimal.TryParse(Salary, out DecSalary))
                    {
                        x = false;
                    }
                } while (x == true);
            }
            return DecSalary;
        }

        public static decimal BonusInput()
        {
            Console.WriteLine("Please enter a Bonus");
            string? Bonus = Console.ReadLine();
            if (decimal.TryParse(Bonus, out decimal DecBonus))
            {
                return DecBonus;
            }
            else
            {
                bool x = true;
                do
                {
                    Console.WriteLine("Please enter a valid Bonus");
                    Bonus = Console.ReadLine();
                    if (decimal.TryParse(Bonus, out DecBonus))
                    {
                        x = false;
                    }
                } while (x == true);
            }
            return DecBonus;
        }

        public static decimal DayRateInput()
        {
            Console.WriteLine("Please enter a Day Rate");
            string? DayRate = Console.ReadLine();
            if (decimal.TryParse(DayRate, out decimal DecDayRate))
            {
                return DecDayRate;
            }
            else
            {
                bool x = true;
                do
                {
                    Console.WriteLine("Please enter a valid Day Rate");
                    DayRate = Console.ReadLine();
                    if (decimal.TryParse(DayRate, out DecDayRate))
                    {
                        x = false;
                    }
                } while (x == true);
            }
            return DecDayRate;
        }
        public static int WeeksWorkedInput()
        {
            Console.WriteLine("Please enter Weeks Worked");
            string? WeeksWorked = Console.ReadLine();
            if (int.TryParse(WeeksWorked, out int IntWeeksWorked))
            {
                return IntWeeksWorked;
            }
            else
            {
                bool x = true;
                do
                {
                    Console.WriteLine("Please enter a valid amount of Weeks Worked");
                    WeeksWorked = Console.ReadLine();
                    if (int.TryParse(WeeksWorked, out IntWeeksWorked))
                    {
                        x = false;
                    }
                } while (x == true);
            }
            return IntWeeksWorked;
        }

    }
}
