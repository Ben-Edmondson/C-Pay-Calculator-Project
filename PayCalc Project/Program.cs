namespace PayCalc_Project
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

                string Selection = Console.ReadLine();
                if (Selection == "1")
                {
                    Console.Clear();
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
                        Console.WriteLine("Employee added!");
                        Console.ReadLine();
                        Console.Clear();
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
                } else if (Selection == "2")
                {
                    repo.Read();

                    repo.ReadSingle(2);
                }else if (Selection == "3")
                {
                    //updates
                }else if (Selection == "4")
                {
                    Console.WriteLine("Would you like to delete one employee or all?");
                    string DelSelect = Console.ReadLine();
                    if (DelSelect == "1")
                    {
                        repo.Delete(2);

                    }else if (DelSelect == "2")
                    {
                        repo.RemoveAll();
                    }
                }
                else
                {
                    Console.WriteLine("This was not a valid option. Please try again.");
                    Console.ReadLine();
                    Console.Clear();
                }


            }
        }
    }
}
