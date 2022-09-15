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
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(Employees, 0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void JohnSmithDataTest()
        {
            List<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }); ;
            //arrange
            decimal tAP = 47500;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(Employees, 0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
        [Test]
        public void ClareJonesDataTest()
        {
            //arrange
            List<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 });

            decimal tAP = 70000;
            //act
            decimal tAPCorrect = Calculations.TotalAnnualPay(Employees, 0);
            //assert
            Assert.That(tAPCorrect, Is.EqualTo(tAP));
        }
    }
}