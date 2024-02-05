using PayCalc.ClassLibrary.Models;
using PayCalc.ClassLibrary.Services;
using NUnit.Framework;

namespace PayCalc_Tests
{
    [TestFixture]
    public class DateCalculationTest
    {
        [TestCase("2023-02-01", 4)]
        [TestCase("2023-03-01", 8)]
        [TestCase("2023-04-01", 12)]
        [TestCase(null, 17)]
        public void TestDateCalculation(DateTime? endDate, int weeksWorkedExpected)
        {
            // Arrange
            DateCalculator dateCalculations = new DateCalculator();
            PermanentEmployee employee = new PermanentEmployee()
            {
                FirstName = "Test",
                LastName = "Test",
                ID = 0001,
                StartDate = new DateTime(2023, 01, 01),
                EndDate = endDate
            };

            // Act
            var weeksWorkedSinceStart = dateCalculations.WeeksWorkedSinceStartDate(employee, new DateTime(2023,05,01));

            // Assert
            Assert.That(weeksWorkedSinceStart, Is.EqualTo(weeksWorkedExpected));
        }
    }

}
