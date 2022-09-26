using PayCalc_Project;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
namespace PayCalc_Tests
{
    [TestFixture]
    public class PermRepoTests
    {
        EmployeePermRepo _repoPerm = new EmployeePermRepo();
        [Test]
        public void UpdateTest()
        {
            //arrange
            decimal Sal = 55000;
            decimal Bonus = 5000m;
            //act
            _repoPerm.employees[0] = _repoPerm.Update(0, "Ben", "Edmondson", Sal, Bonus, null, null);
            decimal? _Sal = _repoPerm.employees[0].Salary;
            decimal? _Bonus = _repoPerm.employees[0].Bonus;
            //assert
            Assert.That(_Sal, Is.EqualTo(Sal));
            Assert.That(_Bonus, Is.EqualTo(Bonus));
        }
        [Test]
        public void AddTest()
        {
            //arrange
            int employeeCounter = _repoPerm.employees.Count() - 1;
            //act
            _repoPerm.AddEmployee("Ben", "Edmondson", 25000, 3000, null, null);
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(_repoPerm.employees.Count()));
        }
        [Test]
        public void RemoveAllTest()
        {
            //act
            _repoPerm.RemoveAll();
            int employeeCounter = 0;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(_repoPerm.employees.Count()));
        }
        [Test]
        public void RemoveOne()
        {
            int employeeCounter = _repoPerm.employees.Count();
            _repoPerm.Delete(0);
            employeeCounter = employeeCounter - 1;
            Assert.That(employeeCounter, Is.EqualTo(_repoPerm.employees.Count()));

        }
    }
}
