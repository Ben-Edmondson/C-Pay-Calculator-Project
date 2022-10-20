using PayCalc_Project;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
namespace PayCalc_Tests
{
    //Moq this
    [TestFixture]
    public class CalculationTests
    {
        PermanentEmployeeRepo _repoPerm = new PermanentEmployeeRepo();
        TemporaryEmployeeRepo _repoTemp = new TemporaryEmployeeRepo();
        TemporaryCalculations _temporaryCalculations = new TemporaryCalculations();
        PermanentCalculations _permanentCalculations = new PermanentCalculations();
        [Test]
        public void JoeBloggsCalculationTestForTax()
        {
            //arrange
            decimal tAP = 6486;
            //act
            decimal tAPCorrect = Math.Round((decimal)_permanentCalculations.TotalAnnualPay();
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataCalculationTestForTax()
        {
            //arrange
            decimal tAP = 6986;
            //act
            decimal tAPCorrect = Math.Round((decimal)_permanentCalculations.TotalAnnualPay();
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesCalculationTestForTax()
        {
            //arrange
            decimal tAP = 15431M;
            //act
            decimal tAPCorrect = Math.Round((decimal)_temporaryCalculations.TotalAnnualPay();
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}