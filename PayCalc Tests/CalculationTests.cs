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
            PermanentEmployeeTaxCalculator _permanentCalculations = new PermanentEmployeeTaxCalculator();
            var tAP = 6486M;
            //act
            var tAPCorrect = _permanentCalculations.TotalTaxPaid(permanentEmployee);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void Can_Calculate_Temporary_Employee_Tax()
        {
            //arrange
            TemporaryEmployee temporaryEmployee = new TemporaryEmployee() { ID = 1001, FirstName = "Ben", LastName = "Edmondson", DayRate = 350, WeeksWorked = 40 };
            TemporaryEmployeeTaxCaculator _temporaryCalculations = new TemporaryEmployeeTaxCaculator();
            var tAP = 15431M;
            //act
            var tAPCorrect = _temporaryCalculations.TotalTaxPaid(temporaryEmployee);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}