using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;

namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeePermRepo repoPerm = new EmployeePermRepo();
            EmployeeTempRepo repoTemp = new EmployeeTempRepo();
            bool GameLoop = true;
            while (GameLoop == true)
            {
                Console.Clear();
                Console.WriteLine(@"Welcome to the PayCalc program!
Please Select an Option Below.
1. Add employee
2. Read Employees
3. Update Employees
4. Delete Employees
5. Total Annual Salary
6.Exit");
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
                        repoPerm.employees.Add(repoPerm.AddEmployee(FirstName, LastName, DecSalary, DecBonus, null, null));
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
                        repoTemp.employees.Add(repoTemp.AddEmployee(FirstName, LastName, null, null, DecDayRate, IntWeeksWorked));
                        Console.WriteLine("Temporary Employee added!");
                    }
                } else if (Selection == "2")
                {
                    Console.WriteLine(@"1.Permanent employees
2.Temporary employees");
                    string ReadTempPerm = Console.ReadLine();
                    Console.WriteLine(@"1.All Employees
2.One employee(enter ID for which");
                    string ReadSelect = Console.ReadLine();
                    if (ReadTempPerm == "1")
                    {
                        if (ReadSelect == "1")
                        {
                            List<EmployeePerm> employeeInfo = repoPerm.ReadAll();
                            for (int i = 0; i < employeeInfo.Count; i++)
                            {
                                Console.WriteLine(employeeInfo[i]);
                            }
                        }
                        else if (ReadSelect == "2")
                        {
                            Console.WriteLine(repoPerm.ReadSingle(0));
                        }
                    }
                    else if (ReadTempPerm == "2")
                    {
                        if (ReadSelect == "1") { 
                            List<EmployeeTemp> employeeInfo = repoTemp.ReadAll();
                            for (int i = 0; i < employeeInfo.Count; i++)
                            {
                            Console.WriteLine(employeeInfo[i]);
                            }
                        }else if (ReadSelect == "2")
                        {
                            Console.WriteLine(repoTemp.ReadSingle(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("This was not a valid choice.");
                    }
                } else if (Selection == "3")
                {
                    repoPerm.employees[0] = repoPerm.Update(0, "Ben", "Edmondson", 60000, 5000, null, null);
                    Console.WriteLine("Employee Updated!");
                }
                else if (Selection == "4")
                {
                    Console.WriteLine("Would you like to delete one employee or all?");
                    string DelSelect = Console.ReadLine();
                    if (DelSelect == "1")
                    {
                       if(repoPerm.Delete(1) == false)
                        {
                            Console.WriteLine("No Employee to be removed at location"!);
                        }
                        else
                        {
                            Console.WriteLine("Employee removed!");
                        }
                    }else if (DelSelect == "2")
                    {
                        if (repoPerm.RemoveAll() == false)
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
                    Console.WriteLine(Calculations.TotalAnnualPayPerm(repoPerm.employees, 0));
                }
                else if (Selection == "6")
                {
                    GameLoop = false;
                    Console.WriteLine("Now Exiting");
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
