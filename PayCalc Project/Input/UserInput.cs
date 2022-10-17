namespace PayCalc_Project.Input
{
    public class UserInput
    {
        public string GetUserInput(string errorMessage)
        {
            var userInput = Console.ReadLine();
            while (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(errorMessage);
                userInput = Console.ReadLine();
            }

            return userInput;
        }
        public decimal GetUserDecimal(string errorMessage)
        {
            var Salary = Console.ReadLine();
            if (!decimal.TryParse(Salary, out decimal DecSalary))
            {
                var x = true;
                while (x)
                {
                    Console.WriteLine(errorMessage);
                    Salary = Console.ReadLine();
                    if (decimal.TryParse(Salary, out DecSalary))
                    {
                        x = false;
                    }
                };
            }

            return DecSalary;
        }
        public int GetUserInt(string errorMessage)
        {
            var WeeksWorked = Console.ReadLine();
            if (!int.TryParse(WeeksWorked, out int IntWeeksWorked))
            { 
                var x = true;
                while (x)
                {
                    Console.WriteLine("Please enter a valid amount of Weeks Worked");
                    WeeksWorked = Console.ReadLine();
                    if (int.TryParse(WeeksWorked, out IntWeeksWorked))
                    {
                        x = false;
                    }
                }
            }
            return IntWeeksWorked;
        }
    }
}
