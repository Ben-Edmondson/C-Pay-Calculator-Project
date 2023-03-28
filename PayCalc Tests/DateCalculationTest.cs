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
            DateCalculations dateCalculations = new DateCalculations();
            PermanentEmployee employee = new PermanentEmployee() { FirstName = "Test", LastName = "Test", ID = 0001, StartDate = new DateTime(2022, 01, 01) };
            //act
            int? weeksWorkedSinceStart = dateCalculations.WeeksWorkedSinceStartDate(employee);
            TimeSpan timeSpan = DateTime.Today - employee.StartDate;
            int checker = (int)timeSpan.TotalDays/7;
            //assert
            Assert.That(weeksWorkedSinceStart, Is.Not.Null);
            Assert.That(weeksWorkedSinceStart, Is.EqualTo(checker));

        }
    }

}
