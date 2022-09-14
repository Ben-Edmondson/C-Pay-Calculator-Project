﻿namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD repo = new CRUD();
            while (true)
            {
                Console.WriteLine(@"Welcome to the PayCalc program!
                                    Please Select an Option Below.
                                    1. Add employee
                                    2. Read Employees
                                    3. Update Employees
                                    4. Delete Employees");

                Console.WriteLine("Add employee?");
                string? employeeAdd = Console.ReadLine();
                if (employeeAdd == "y")
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

                    if (EmployeeType.ToLower() == "permanent")
                    {
                        Console.WriteLine("Please enter a salary");
                        string? Salary = Console.ReadLine();
                        if (decimal.TryParse(Salary, out decimal DecSalary)) ;
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
                        Console.WriteLine("Please enter a Bonus");
                        string? Bonus = Console.ReadLine();
                        if (decimal.TryParse(Bonus, out decimal DecBonus)) ;
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
                        repo.AddPermanentEmployee(FirstName, LastName, DecSalary, DecBonus);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a Day Rate");
                        string? DayRate = Console.ReadLine();
                        if (decimal.TryParse(DayRate, out decimal DecDayRate)) ;
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
                        Console.WriteLine("Please enter Weeks Worked");
                        string? WeeksWorked = Console.ReadLine();
                        if (int.TryParse(WeeksWorked, out int IntWeeksWorked)) ;
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
                        repo.AddTempEmployee(FirstName, LastName, DecDayRate, IntWeeksWorked);
                    }
                }
                repo.Read(employees);
                repo.ReadSingle(employees, 2);
            }
        }
    }
}
