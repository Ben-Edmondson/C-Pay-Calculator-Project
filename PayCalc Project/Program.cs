using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using PayCalc_Project.Input;

namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeePermRepo repoPerm = new EmployeePermRepo();
            EmployeeTempRepo repoTemp = new EmployeeTempRepo();
            PermCalculations permCalculations = new PermCalculations();
            UserInput userInput = new UserInput();
            var gameLoop = true;
            while (gameLoop == true)
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
                var Selection = Console.ReadLine();
                Console.Clear();
                if (Selection == "1")
                {
                    Console.WriteLine("Is employee permanent or temporary?");
                    string? employeeType = userInput.GetUserInput("Please enter a valid employment type!");

                    Console.WriteLine("Enter a first name");
                    var firstName = userInput.GetUserInput("Please enter a valid first name!");

                    Console.WriteLine("Please enter a last name");
                    var lastName = userInput.GetUserInput("Please enter a valid last name!");

                    if (employeeType.ToLower() == "permanent")
                    {
                        Console.WriteLine("Please enter a salary");

                        var decSalary = userInput.GetUserDecimal("Please enter a valid Salary");
                        Console.WriteLine("Please enter a Bonus");
                        var decBonus = userInput.GetUserDecimal("Please enter a valid Bonus");
                        repoPerm.employees.Add(repoPerm.Create(firstName, lastName, decSalary, decBonus, null, null));
                        Console.WriteLine("Permanent Employee added!");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a Day Rate");
                        var DayRate = userInput.GetUserDecimal("Please enter a valid Day Rate");
                        Console.WriteLine("Please enter Weeks Worked");
                        int IntWeeksWorked = userInput.GetUserInt("Please enter a valid amount of weeks worked!");
                        repoTemp.AddEmployee(repoTemp.Create(firstName, lastName, null, null, DayRate, IntWeeksWorked));
                        Console.WriteLine("Temporary Employee added!");
                    }
                }
                else if (Selection == "2")
                {
                    Console.WriteLine(@"1.Permanent employees
2.Temporary employees");
                    var ReadTempPerm = Console.ReadLine();
                    Console.WriteLine(@"1.All Employees
2.One employee");
                    var readSelect = Console.ReadLine();
                    if (ReadTempPerm == "1")
                    {
                        if (readSelect == "1")
                        {
                            List<EmployeePerm> employeeInfo = repoPerm.ReadAll();
                            foreach(EmployeePerm employee in employeeInfo)
                            {
                                Console.WriteLine(employee);
                            }
                        }
                        else if (readSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            var SelectID = userInput.GetUserInt("Please enter a valid number");
                            if(repoPerm.ReadSingle(SelectID) != null)
                            {
                                Console.WriteLine(repoPerm.ReadSingle(SelectID));
                            }
                            else
                            {
                                Console.WriteLine("No user with this ID exists");
                            }
                        }
                    }
                    else if (ReadTempPerm == "2")
                    {
                        if (readSelect == "1") { 
                            List<EmployeeTemp> employeeInfo = repoTemp.ReadAll();
                            foreach(EmployeeTemp employee in employeeInfo)
                            {
                            Console.WriteLine(employee);
                            }
                        }else if (readSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            var selectID = userInput.GetUserInt("Select a valid number");
                            if (repoTemp.ReadSingle(selectID) != null)
                            {
                                Console.WriteLine(repoPerm.ReadSingle(selectID));
                            }
                            else
                            {
                                Console.WriteLine("No user with this ID exists");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("This was not a valid choice.");
                    }
                } else if (Selection == "3")
                {
                    repoPerm.Update(1112, "Ben", "Edmondson", 60000, 5000, null, null);
                    Console.WriteLine("Employee Updated!");
                }
                else if (Selection == "4")
                {
                    Console.WriteLine(@"1.Delete Permanent employees
2.Delete Temporary employees");
                    string? DelSelect = Console.ReadLine();
                    Console.WriteLine(@"1.One Employee
2.All Employees");
                    var DelSec = Console.ReadLine();
                    if (DelSelect == "1")
                    {
                        if (DelSec == "1")
                        {
                            Console.WriteLine("Please enter an ID");
                            var ID = userInput.GetUserInt("Please enter a valid number!");
                            if (repoPerm.Delete(ID) == false)
                            {
                                Console.WriteLine("No Employee to be removed with this ID!"!);
                            }
                            else
                            {
                                Console.WriteLine("Employee removed!");
                            }
                        }else if(DelSec == "2")
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
                    }else if (DelSelect == "2")
                    {
                        if (DelSec == "1")
                        {
                            Console.WriteLine("Please enter an ID");
                            var ID = userInput.GetUserInt("Please enter a valid number");
                            if (repoTemp.Delete(ID) == false)
                            {
                                Console.WriteLine("No Employee to be removed at location"!);
                            }
                            else
                            {
                                Console.WriteLine("Employee removed!");
                            }
                        }
                        else if (DelSec == "2")
                        {
                            if (repoTemp.RemoveAll() == false)
                            {
                                Console.WriteLine("No Employees to be removed!");
                            }
                            else
                            {
                                Console.WriteLine("Employees wiped!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("This was not a valid option. Please try again.");
                    }
                }
                else if (Selection == "5")
                {
                    Console.WriteLine(permCalculations.TotalAnnualPay(repoPerm.employees, 0));
                }
                else if (Selection == "6")
                {
                    gameLoop = false;
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
