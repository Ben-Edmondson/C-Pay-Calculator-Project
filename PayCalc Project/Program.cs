namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository repo = new EmployeeRepository();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Welcome to the PayCalc program!
                                    Please Select an Option Below.
                                    1. Add employee
                                    2. Read Employees
                                    3. Update Employees
                                    4. Delete Employees
                                    5. Total Annual Salary (pretax)");

                string Selection = Console.ReadLine();
                Console.Clear();
                if (Selection == "1")
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
                        Console.WriteLine("Permanent Employee added!");
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
                        Console.WriteLine("Temporary Employee added!");
                    }
                } else if (Selection == "2")
                {
                    Console.WriteLine("Would you like to see all employees or 1?");
                    string ReadSelect = Console.ReadLine();
                    if (ReadSelect == "1")
                    {
                        List<string> employeeInfo = repo.Read();
                        for(int i = 0; i < employeeInfo.Count; i++)
                        {
                            Console.WriteLine(employeeInfo[i]);
                        }
<<<<<<< Updated upstream
                        Console.ReadLine();
                    }else if (ReadSelect == "2")
                    {
                        Console.WriteLine(repo.ReadSingle(0));
=======
                        else if (readSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            var selectID = userInput.GetUserInt("Please enter a valid number");
                            if (permanentRepository.Read(selectID) != null)
                            {
                                Console.WriteLine(permanentRepository.Read(selectID));
                            }
                            else
                            {
                                Console.WriteLine("No user with this ID exists");
                            }
                        }
                    }
                    else if (readTempPerm == "2")
                    {
                        if (readSelect == "1")
                        {
                            List<TemporaryEmployee> employeeInfo = temporaryRepository.ReadAll();
                            foreach (TemporaryEmployee employee in employeeInfo)
                            {
                                Console.WriteLine(employee);
                            }
                        }
                        else if (readSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            var selectID = userInput.GetUserInt("Select a valid number");
                            if (temporaryRepository.Read(selectID) != null)
                            {
                                Console.WriteLine(permanentRepository.Read(selectID));
                            }
                            else
                            {
                                Console.WriteLine("No user with this ID exists");
                            }
                        }
>>>>>>> Stashed changes
                    }
                    else
                    {
                        Console.WriteLine("This was not a valid choice.");
                    }



                }else if (Selection == "3")
                {
                   if( repo.UpdatePerm(0, "Ben", "Edmondson", 60000, 5000))
                    {
                        Console.WriteLine("Employee updated!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update Employee");
                    }

                }else if (Selection == "4")
                {
                    Console.WriteLine("Would you like to delete one employee or all?");
                    string DelSelect = Console.ReadLine();
                    if (DelSelect == "1")
                    {
                       if(repo.Delete(2) == false)
                        {
                            Console.WriteLine("No Employee to be removed at location"!);
                        }
                        else
                        {
                            Console.WriteLine("Employee removed!");
                        }

                    }else if (DelSelect == "2")
                    {
                        if (repo.RemoveAll() == false)
                        {
                            Console.WriteLine("No Employees to be removed!");
                        }
                        else
                        {
                            Console.WriteLine("Employees wiped!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This was not a valid option. Please try again.");
                    }
                }
                else if (Selection == "5")
                {
<<<<<<< Updated upstream
                    Console.WriteLine(Calculations.TotalAnnualPay(repo.employees,0));
=======
                    Console.WriteLine(@"1.Permanent employees
2.Temporary employees");
                    var readTempPerm = userInput.GetUserInput("Please enter a choice.");
                    if (readTempPerm.ToLower() == "permanent")
                    {
                        Console.WriteLine("Please enter an ID");
                        var id = userInput.GetUserInt("Please enter a valid number!");
                        PermanentEmployee? employee = permanentRepository.Read(id);
                        if (employee == null)
                        {
                            Console.WriteLine("This was not a valid ID ");
                        }
                        else
                        {
                            Console.WriteLine(permanentCalculations.TotalAnnualPay(employee));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter an ID");
                        var ID = userInput.GetUserInt("Please enter a valid number!");
                        TemporaryEmployee? employee = temporaryRepository.Read(ID);
                        if (employee == null)
                        {
                            Console.WriteLine("This was not a valid ID ");
                        }
                        else
                        {
                            Console.WriteLine(temporaryCalculations.TotalAnnualPay(employee));
                        }
                    }
                }
                else if (selection == "6")
                {
                    gameLoop = false;
                    Console.WriteLine("Now Exiting");
>>>>>>> Stashed changes
                }
                else
                {
                    Console.WriteLine("You did not pick a valid option");
                }
                Console.ReadLine();
            }
        }
    }
}
