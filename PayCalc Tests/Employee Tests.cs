using PayCalc_Project;
namespace PayCalc_Tests
{
    [TestFixture]
    public class EmployeeTests
    {

        [Test]
        public void JoeBloggsDataTest()
        {
            List<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 });
            //arrange
            decimal tAP = 45000;
            decimal hrActual = 21.98M;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(Employees, 0);
            decimal hrCorrect = Calculations.doubleHourlyRate(Employees, 0);
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            List<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }); ;
            //arrange
            decimal tAP = 47500;
            decimal hrActual = 24.73M;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(Employees, 0);
            decimal hrCorrect = Calculations.doubleHourlyRate(Employees, 0);
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            List<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 });

            decimal tAP = 70000;
            decimal hrActual = 50;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(Employees, 0);
            decimal hrCorrect = Calculations.doubleHourlyRate(Employees, 0);
            //assert
            Assert.That(hrCorrect, Is.EqualTo(hrActual));
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}