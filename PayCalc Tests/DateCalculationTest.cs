using PayCalc_Project.Models;
using PayCalc_Project.Services;
using NUnit.Framework;

namespace PayCalc_Tests
{
    [TestFixture]
    public class DateCalculationTest
    {
        [TestCase("2023-01-01")]
        [TestCase("2023-06-06")]
        [TestCase("2022-01-01")]
        public void TestDateCalculation(DateTime startDate) 
        {
            //arrange
            DateCalculator dateCalculations = new DateCalculator();
            PermanentEmployee employee = new PermanentEmployee() { FirstName = "Test", LastName = "Test", ID = 0001, StartDate = startDate };
            //act
            var weeksWorkedSinceStart = dateCalculations.WeeksWorkedSinceStartDate(employee);
            TimeSpan timeSpan = DateTime.Today - employee.StartDate;
            var checker = (int)timeSpan.TotalDays/7;
            //assert
            Assert.That(weeksWorkedSinceStart, Is.EqualTo(checker));

        }
    }

}
