using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project
{
    class Input
    {

        public static string FirstNameInput()
        {
            Console.WriteLine("Enter a first name");
            string? FirstName = Console.ReadLine();
            if(FirstName == "")
            {
                do
                {
                    Console.WriteLine("Please enter a valid First Name!");
                    FirstName = Console.ReadLine();
                } while(FirstName == "");
            }
            return FirstName;
        }
        public static string LastNameInput()
        {
            Console.WriteLine("Please enter a last name");
            string? LastName = Console.ReadLine();
            if (LastName == "")
            {
                do
                {
                    Console.WriteLine("Please enter a valid Last Name!");
                    LastName = Console.ReadLine();
                } while (LastName == "");
            }
            return LastName;
        }
        public static decimal SalaryInput()
        {
            Console.WriteLine("Please enter a salary");
            string? Salary = Console.ReadLine();
            if(decimal.TryParse(Salary, out decimal DecSalary))
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

        public static decimal DayRate()
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
        public static int WeeksWorked()
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
