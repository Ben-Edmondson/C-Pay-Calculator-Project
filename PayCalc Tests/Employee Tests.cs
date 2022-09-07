using PayCalc_Project;
using System.Data;
namespace PayCalc_Tests
{
    public class EmployeeTests
    {

        [Test]
        public void JoeBloggsDataTest()
        {
            //arrange
            Employee joeBloggs = new Employee() {GuID = Guid.NewGuid() ,EmploymentType = TypeOfEmployment.Permanent, FirstName = "Joe", LastName = "Bloggs", Salary =40000, Bonus = 5000};
            decimal tAP = 45000;
            decimal hrActual = 21.98M;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay();
            decimal hrCorrect = Calculations.doubleHourlyRate();
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            //arrange
            Employee johnSmith = new Employee() { GuID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 };
            decimal tAP = 47500;
            decimal hrActual = 24.73M;
            //act
            decimal tAPCorrect = johnSmith.TotalAnnualPay();
            decimal hrCorrect = johnSmith.doubleHourlyRate();
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            Employee clareJones = new Employee() { GuID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare",LastName = "Jones", DayRate = 350, WeeksWorked = 40};
            decimal tAP = 70000;
            decimal hrActual = 50;
            //act
            decimal tAPCorrect = clareJones.TotalAnnualPay();
            decimal hrCorrect = clareJones.doubleHourlyRate();
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}