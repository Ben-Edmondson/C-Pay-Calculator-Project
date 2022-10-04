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
            decimal? tAP = 6486;
            //act
            decimal? tAPCorrect = Math.Round((decimal)Calculations.TotalAnnualPayPerm(_repoPerm.employees,0),0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            //arrange
            decimal? tAP = 6986;
            //act
            decimal? tAPCorrect = Math.Round((decimal)Calculations.TotalAnnualPayPerm(_repoPerm.employees,1),0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            decimal? tAP = 15431M;
            //act
            decimal? tAPCorrect = Math.Round((decimal)Calculations.TotalAnnualPayTemp(_repoTemp.employees, 0),0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}