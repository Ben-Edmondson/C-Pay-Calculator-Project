using PayCalc_Project;
namespace PayCalc_Tests
{
    public class EmployeeTests
    {

        [Test]
        public void TotalAnnPayPerm()
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
        public void TotalHourlyPerm()
        {
            //arrange
            Employee employee = new Employee();
            double actual = 10.99;
            //act
            double result = employee.doubleHourlyRate();
            //assert
            Assert.That(result, Is.EqualTo(actual));

        }

        [Test]
        public void TotalHourlyTemp()
        {
            //arrange
            TempEmployee employee = new TempEmployee();
            double actual = 42.86;
            //act
            double result = employee.doubleHourlyRate();
            //assert
            Assert.That(result, Is.EqualTo(actual));
        }

        [Test]
        public void TotalAnnPayTemp()
        {
            //arrange
            TempEmployee tempEmployee = new TempEmployee();
            double actual = 45000;
            //act
            double result = tempEmployee.TotalAnnualPay();
            Assert.That(result, Is.EqualTo(actual));
        }
    }
}