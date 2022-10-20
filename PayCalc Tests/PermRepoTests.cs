using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class PermRepoTests
    {
        PermanentEmployeeRepo _repoPerm = new PermanentEmployeeRepo();
        [Test]
        public void UpdateTest()
        {
            //arrange
            decimal Sal = 55000;
            decimal Bonus = 5000m;
            //act
            _repoPerm.Update(1112, "Ben", "Edmondson", Sal, Bonus, null, null);
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
            _repoPerm.Create("Ben", "Edmondson", 25000, 3000, null, null);
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(_repoPerm.employees.Count()));
        }
        [Test]
        public void RemoveAllTest()
        {
            Assert.That(_repoPerm.RemoveAll(), Is.EqualTo(true));
        }
        [Test]
        public void RemoveOne()
        {
            Assert.That(_repoPerm.Delete(1112), Is.EqualTo(true));
            Assert.That(_repoPerm.Delete(1111), Is.EqualTo(false));

        }
    }
}
