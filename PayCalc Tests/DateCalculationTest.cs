using PayCalc_Project.Models;
using PayCalc_Project.Services;

namespace PayCalc_Tests
{
    [TestFixture]
    public class DateCalculationTest
    {
        [Test]
        public void TestDateCalculation() 
        {
            //arrange
            DateCalculator dateCalculations = new DateCalculator();
            PermanentEmployee employee = new PermanentEmployee() { FirstName = "Test", LastName = "Test", ID = 0001, StartDate = new DateTime(2022, 01, 01) };
            //act
            var weeksWorkedSinceStart = dateCalculations.WeeksWorkedSinceStartDate(employee);
            TimeSpan timeSpan = DateTime.Today - employee.StartDate;
            var checker = (int)timeSpan.TotalDays/7;
            //assert
            Assert.That(weeksWorkedSinceStart, Is.EqualTo(checker));

        }
    }

}
