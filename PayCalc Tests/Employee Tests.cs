using PayCalc_Project;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
namespace PayCalc_Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        EmployeePermRepo _repoPerm = new EmployeePermRepo();
        EmployeeTempRepo _repoTemp = new EmployeeTempRepo();
        [Test]
        public void JoeBloggsDataTest()
        {
            //arrange
            decimal? tAP = 45000;
            //act
            decimal? tAPCorrect = Calculations.TotalAnnualPayPerm(_repoPerm.employees,0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            //arrange
            decimal? tAP = 47500;
            //act
            decimal? tAPCorrect = Calculations.TotalAnnualPayPerm(_repoPerm.employees,1);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            decimal? tAP = 70000;
            //act
            decimal? tAPCorrect = Calculations.TotalAnnualPayTemp(_repoTemp.employees, 0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}