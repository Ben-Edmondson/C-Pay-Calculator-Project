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
            var numberToParse = Console.ReadLine();
            var numberParsed = 0M;
            while (!decimal.TryParse(numberToParse, out numberParsed))
            {
                Console.WriteLine(errorMessage);
                numberToParse = Console.ReadLine();
            }
            return numberParsed;
        }
        public int GetUserInt(string errorMessage)
        {
            var intParsed = 0;
            var intToParse = Console.ReadLine();
            while (!int.TryParse(intToParse, out intParsed))
            {
                Console.WriteLine(errorMessage);
                intToParse = Console.ReadLine();
            }
            return intParsed;
        }
    }
}
