using PayCalc_Project.Input;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;

namespace PayCalc_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            PermanentEmployeeRepo permanentRepository = new PermanentEmployeeRepo();
            TemporaryEmployeeRepo temporaryRepository = new TemporaryEmployeeRepo();
            PermanentCalculations permanentCalculations = new PermanentCalculations();
            TemporaryCalculations temporaryCalculations = new TemporaryCalculations();
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
                var selection = Console.ReadLine();
                Console.Clear();
                if (selection == "1")
                {
                    Console.WriteLine("Is employee permanent or temporary?");
                    var employeeType = userInput.GetUserInput("Please enter a valid employment type!");

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
                        permanentRepository.Create(firstName, lastName, decSalary, decBonus, null, null);
                        Console.WriteLine("Permanent Employee added!");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a Day Rate");
                        var dayRate = userInput.GetUserDecimal("Please enter a valid Day Rate");
                        Console.WriteLine("Please enter Weeks Worked");
                        var weeksWorked = userInput.GetUserInt("Please enter a valid amount of weeks worked!");
                        temporaryRepository.Create(firstName, lastName, null, null, dayRate, weeksWorked);
                        Console.WriteLine("Temporary Employee added!");
                    }
                }
                else if (selection == "2")
                {
                    Console.WriteLine(@"1.Permanent employees
2.Temporary employees");
                    var readTempPerm = Console.ReadLine();
                    Console.WriteLine(@"1.All Employees
2.One employee");
                    var readSelect = Console.ReadLine();
                    if (readTempPerm == "1")
                    {
                        if (readSelect == "1")
                        {
                            List<PermanentEmployee> employeeInfo = permanentRepository.ReadAll();
                            foreach (PermanentEmployee employee in employeeInfo)
                            {
                                Console.WriteLine(employee);
                            }
                        }
                        else if (readSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            var selectID = userInput.GetUserInt("Please enter a valid number");
                            if (permanentRepository.ReadSingle(selectID) != null)
                            {
                                Console.WriteLine(permanentRepository.ReadSingle(selectID));
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
                            if (temporaryRepository.ReadSingle(selectID) != null)
                            {
                                Console.WriteLine(permanentRepository.ReadSingle(selectID));
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
                }
                else if (selection == "3")
                {
                    permanentRepository.Update(1112, "Ben", "Edmondson", 60000, 5000, null, null);
                    Console.WriteLine("Employee Updated!");
                }
                else if (selection == "4")
                {
                    Console.WriteLine(@"1.Delete Permanent employees
2.Delete Temporary employees");
                    string? delSelect = Console.ReadLine();
                    Console.WriteLine(@"1.One Employee
2.All Employees");
                    var delSec = Console.ReadLine();
                    if (delSelect == "1")
                    {
                        if (delSec == "1")
                        {
                            Console.WriteLine("Please enter an ID");
                            var id = userInput.GetUserInt("Please enter a valid number!");
                            if (permanentRepository.Delete(id) == false)
                            {
                                Console.WriteLine("No Employee to be removed with this ID!"!);
                            }
                            else
                            {
                                Console.WriteLine("Employee removed!");
                            }
                        }
                        else if (delSec == "2")
                        {
                            if (permanentRepository.RemoveAll() == false)
                            {
                                Console.WriteLine("No Employees to be removed!");
                            }
                            else
                            {
                                Console.WriteLine("Employees wiped!");
                            }
                        }
                    }
                    else if (delSelect == "2")
                    {
                        if (delSec == "1")
                        {
                            Console.WriteLine("Please enter an ID");
                            var id = userInput.GetUserInt("Please enter a valid number");
                            if (temporaryRepository.Delete(id) == false)
                            {
                                Console.WriteLine("No Employee to be removed at location"!);
                            }
                            else
                            {
                                Console.WriteLine("Employee removed!");
                            }
                        }
                        else if (delSec == "2")
                        {
                            if (temporaryRepository.RemoveAll() == false)
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
                else if (selection == "5")
                {
                    Console.WriteLine(@"1.Permanent employees
2.Temporary employees");
                    var readTempPerm = userInput.GetUserInput("Please enter a choice.");
                    if (readTempPerm.ToLower() == "permanent")
                    {
                        Console.WriteLine("Please enter an ID");
                        var id = userInput.GetUserInt("Please enter a valid number!");
                        PermanentEmployee? employee = permanentRepository.ReadSingle(id);
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
                        TemporaryEmployee? employee = temporaryRepository.ReadSingle(ID);
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
