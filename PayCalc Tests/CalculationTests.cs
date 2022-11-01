using PayCalc_Project.Models;
using PayCalc_Project.Services;

namespace PayCalc_Tests
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void Can_Calculate_Permanent_Employee_Tax()
        {
            //arrange
            PermanentEmployee permanentEmployee = new PermanentEmployee() { ID = 1001, FirstName = "Ben", LastName = "Edmondson", Bonus = 5000, Salary = 40000 };
            PermanentCalculations _permanentCalculations = new PermanentCalculations();
            decimal tAP = 6486;
            //act
            decimal tAPCorrect = Math.Round((decimal)_permanentCalculations.TotalAnnualPay(permanentEmployee));
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void Can_Calculate_Temporary_Employee_Tax()
        {
            //arrange
            TemporaryEmployee temporaryEmployee = new TemporaryEmployee() { ID = 1001, FirstName = "Ben", LastName = "Edmondson", DayRate = 350, WeeksWorked = 40 };
            TemporaryCalculations _temporaryCalculations = new TemporaryCalculations();
            decimal tAP = 15431M;
            //act
            decimal tAPCorrect = Math.Round((decimal)_temporaryCalculations.TotalAnnualPay(temporaryEmployee));
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}