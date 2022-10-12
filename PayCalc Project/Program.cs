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
                string? Selection = Console.ReadLine();
                Console.Clear();
                if (Selection == "1")
                {
                    Console.WriteLine("Is employee permanent or temporary?");
                    string? EmployeeType = Console.ReadLine();
                    if (String.IsNullOrEmpty(EmployeeType))
                    {
                        while (String.IsNullOrEmpty(EmployeeType))
                        {
                            Console.WriteLine("Please enter a valid employment type");
                            EmployeeType = Console.ReadLine();
                        }
                    }
                    Console.WriteLine("Enter a first name");
                    string? FirstName = Console.ReadLine();
                    if (String.IsNullOrEmpty(FirstName))
                    {
                        while(String.IsNullOrEmpty(FirstName))
                        {
                            Console.WriteLine("Please enter a valid First Name!");
                            FirstName = Console.ReadLine();
                        }
                    }
                    Console.WriteLine("Please enter a last name");
                    string? LastName = Console.ReadLine();
                    if (String.IsNullOrEmpty(LastName)) 
                    {
                        while(String.IsNullOrEmpty(LastName))
                        {
                            Console.WriteLine("Please enter a valid Last Name!");
                            LastName = Console.ReadLine();
                        }
                    }
                    if (EmployeeType.ToLower() == "permanent")
                    {
                        Console.WriteLine("Please enter a salary");
                        string? Salary = Console.ReadLine();
                        if (decimal.TryParse(Salary, out decimal DecSalary))
                        {

                        }
                        else
                        {
                            bool x = true;
                            while (x == true)
                            {
                                Console.WriteLine("Please enter a valid salary");
                                Salary = Console.ReadLine();
                                if (decimal.TryParse(Salary, out DecSalary))
                                {
                                    x = false;
                                }
                            } ;
                        }
                        Console.WriteLine("Please enter a Bonus");
                        string? Bonus = Console.ReadLine();
                        if (decimal.TryParse(Bonus, out decimal DecBonus))
                        {

                        }
                        else
                        {
                            bool x = true;
                            while (x == true)
                            {
                                Console.WriteLine("Please enter a valid Bonus");
                                Bonus = Console.ReadLine();
                                if (decimal.TryParse(Bonus, out DecBonus))
                                {
                                    x = false;
                                }
                            } ;
                        }
                        repoPerm.employees.Add(repoPerm.AddEmployee(FirstName, LastName, DecSalary, DecBonus, null, null));
                        Console.WriteLine("Permanent Employee added!");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a Day Rate");
                        string? DayRate = Console.ReadLine();
                        if (decimal.TryParse(DayRate, out decimal DecDayRate))
                        {

                        }
                        else
                        {
                            bool x = true;
                            while (x == true)
                            {
                                Console.WriteLine("Please enter a valid Day Rate");
                                DayRate = Console.ReadLine();
                                if (decimal.TryParse(DayRate, out DecDayRate))
                                {
                                    x = false;
                                }
                            } ;
                        }
                        Console.WriteLine("Please enter Weeks Worked");
                        string? WeeksWorked = Console.ReadLine();
                        if (int.TryParse(WeeksWorked, out int IntWeeksWorked))
                        {

                        }
                        else
                        {
                            bool x = true;
                            while (x == true)
                            {
                                Console.WriteLine("Please enter a valid amount of Weeks Worked");
                                WeeksWorked = Console.ReadLine();
                                if (int.TryParse(WeeksWorked, out IntWeeksWorked))
                                {
                                    x = false;
                                }
                            }
                        }
                        repoTemp.employees.Add(repoTemp.AddEmployee(FirstName, LastName, null, null, DecDayRate, IntWeeksWorked));
                        Console.WriteLine("Temporary Employee added!");
                    }
                } else if (Selection == "2")
                {
                    Console.WriteLine(@"1.Permanent employees
2.Temporary employees");
                    string? ReadTempPerm = Console.ReadLine();
                    Console.WriteLine(@"1.All Employees
2.One employee");
                    string? ReadSelect = Console.ReadLine();
                    if (ReadTempPerm == "1")
                    {
                        if (ReadSelect == "1")
                        {
                            List<EmployeePerm> employeeInfo = repoPerm.ReadAll();
                            foreach(EmployeePerm employee in employeeInfo)
                            {
                                Console.WriteLine(employee);
                            }
                        }
                        else if (ReadSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            string? SelectID = Console.ReadLine();
                            if (int.TryParse(SelectID, out int IntSelectID))
                            {

                            }
                            else
                            {
                                bool x = true;
                                while (x == true)
                                {
                                    Console.WriteLine("Please enter a valid number");
                                    if(int.TryParse(SelectID, out IntSelectID))
                                    {
                                        x = false;
                                    }
                                }
                            }
                            if(repoPerm.ReadSingle(IntSelectID) != null)
                            {
                                Console.WriteLine(repoPerm.ReadSingle(IntSelectID));

                            }
                            else
                            {
                                Console.WriteLine("No user with this ID exists");
                            }
                        }
                    }
                    else if (ReadTempPerm == "2")
                    {
                        if (ReadSelect == "1") { 
                            List<EmployeeTemp> employeeInfo = repoTemp.ReadAll();
                            foreach(EmployeeTemp employee in employeeInfo)
                            {
                            Console.WriteLine(employee);
                            }
                        }else if (ReadSelect == "2")
                        {
                            Console.WriteLine("Select an employee ID");
                            string? SelectID = Console.ReadLine();
                            if (int.TryParse(SelectID, out int IntSelectID))
                            {

                            }
                            else
                            {

                                bool x = true;
                                while (x == true)
                                {
                                    Console.WriteLine("Please enter a valid number");
                                    if (int.TryParse(SelectID, out IntSelectID))
                                    {
                                        x = false;
                                    }
                                }
                            }
                            if (repoTemp.ReadSingle(IntSelectID) != null)
                            {
                                Console.WriteLine(repoPerm.ReadSingle(IntSelectID));
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
                    repoPerm.Update(0, "Ben", "Edmondson", 60000, 5000, null, null);
                    Console.WriteLine("Employee Updated!");
                }
                else if (Selection == "4")
                {
                    Console.WriteLine(@"1.Delete Permanent employees
2.Delete Temporary employees");
                    string? DelSelect = Console.ReadLine();
                    Console.WriteLine(@"1.One Employee
2.All Employees");
                    string? DelSec = Console.ReadLine();
                    if (DelSelect == "1")
                    {
                        if (DelSec == "1")
                        {
                            Console.WriteLine("Please enter an ID");
                            string? ID = Console.ReadLine();
                            if (int.TryParse(ID, out int IntID))
                            {

                            }
                            else
                            {
                                bool x = true;
                                while (x == true)
                                {
                                    Console.WriteLine("Please enter a valid number");
                                    if (int.TryParse(ID, out IntID))
                                    {
                                        x = false;
                                    }
                                }
                            }
                            if (repoPerm.Delete(IntID) == false)
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
                            string? ID = Console.ReadLine();
                            if (int.TryParse(ID, out int IntID))
                            {

                            }
                            else
                            {
                                bool x = true;
                                while (x == true)
                                {
                                    Console.WriteLine("Please enter a valid number");
                                    if (int.TryParse(ID, out IntID))
                                    {
                                        x = false;
                                    }
                                }
                            }
                            if (repoTemp.Delete(IntID) == false)
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
