using PayCalc_Project;
namespace PayCalc_Tests
{
    public class EmployeeTests
    {

        [Test]
        public void JoeBloggsDataTest()
        {
            //arrange
            Employee joeBloggs = new Employee() {typeOfEmployment = "Permanent", fname = "Joe", lname = "Bloggs", aSalary =40000, aBonus = 5000};
            double tAP = 45000;
            double hrActual = 21.98;
            //act
            double tAPCorrect = joeBloggs.TotalAnnualPay();
            double hrCorrect = joeBloggs.doubleHourlyRate();
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            //arrange
            Employee johnSmith = new Employee() { typeOfEmployment = "Permanent", fname = "John", lname = "Smith", aSalary = 45000, aBonus = 2500 };
            double tAP = 47500;
            double hrActual = 24.73;
            //act
            double tAPCorrect = johnSmith.TotalAnnualPay();
            double hrCorrect = johnSmith.doubleHourlyRate();
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            Employee clareJones = new Employee() { typeOfEmployment = "Temporary", fname = "Clare", lname = "Jones", dayRate = 350, weeksWorked = 40};
            double tAP = 70000;
            double hrActual = 50;
            //act
            double tAPCorrect = clareJones.TotalAnnualPay();
            double hrCorrect = clareJones.doubleHourlyRate();
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}