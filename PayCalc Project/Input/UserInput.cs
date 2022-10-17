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
            var DecSalary = 0M;
                while (!decimal.TryParse(Salary,out DecSalary))
                {
                    Console.WriteLine(errorMessage);
                    Salary = Console.ReadLine();
                }
            return DecSalary;
        }
        public int GetUserInt(string errorMessage)
        {
            var IntWeeksWorked = 0;
            var WeeksWorked = Console.ReadLine();
            while (!int.TryParse(WeeksWorked, out IntWeeksWorked))
            {
                Console.WriteLine("Please enter a valid amount of Weeks Worked");
                WeeksWorked = Console.ReadLine();
            }
            return IntWeeksWorked;
        }
    }
}
