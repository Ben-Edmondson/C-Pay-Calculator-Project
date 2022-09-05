using PayCalc_Project;
namespace PayCalc_Tests
{
    public class EmployeeTests
    {

        [Test]
        public void TotalAnnPay()
        {
            //arrange
            Employee employee = new Employee();
            double tAP = 22000;
            //act
            double tAPCorrect = employee.TotalAnnualPay();
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }

        [Test]
        public void TotalHourly()
        {
            //arrange
            Employee employee = new Employee();
            double actual = 10.99;
            //act
            double result = employee.doubleHourlyRate();
            //assert
            Assert.That(result, Is.EqualTo(actual));

        }
    }
}