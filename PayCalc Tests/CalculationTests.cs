using PayCalc_Project.Repository;
using PayCalc_Project.Services;
using Moq;
using PayCalc_Project.Models;

namespace PayCalc_Tests
{
    [TestFixture]
    public class CalculationTests
    {
        //moq repo
        [Test]
        public void Can_Calculate_Permanent_Employee_Tax()
        {
            //arrange
            var _repoPerm = new Mock<IEmployeeRepository<PermanentEmployee>();
            _repoPerm.Setup(x => x.ReadAll()).Returns(new List<PermanentEmployee>{new PermanentEmployee { ID = 1001,FirstName = "Ben", LastName = "Edmondson",Bonus = 5000, Salary = 30000} },
            new PermanentEmployee { ID = 2002, FirstName = "Sally", LastName = "Harbinger", Salary = 50000, Bonus = 5000 });

            PermanentCalculations _permanentCalculations = new PermanentCalculations();
            decimal tAP = 6486;
            //act
            decimal tAPCorrect = Math.Round((decimal)_permanentCalculations.TotalAnnualPay(1001));
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void Can_Calculate_Temporary_Employee_Tax()
        {
            //arrange
            var _repoTemp = new Mock<TemporaryEmployeeRepo>();
            TemporaryCalculations _temporaryCalculations = new TemporaryCalculations();
            decimal tAP = 15431M;
            //act
            decimal tAPCorrect = Math.Round((decimal)_temporaryCalculations.TotalAnnualPay());
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}