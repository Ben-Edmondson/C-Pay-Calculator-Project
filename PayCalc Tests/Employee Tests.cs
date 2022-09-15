using PayCalc_Project;
namespace PayCalc_Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        CRUD _repo = new CRUD();
        [Test]
        public void JoeBloggsDataTest()
        {
            //arrange
            decimal tAP = 45000;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(_repo.employees,0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            //arrange
            decimal tAP = 47500;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(_repo.employees,1);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            decimal tAP = 70000;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(_repo.employees, 2);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}