using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class TempRepoTests
    {
        EmployeeTempRepo _repoTemp = new EmployeeTempRepo();
        [Test]
        public void UpdateTest()
        {
            //arrange
            decimal? DayRate = 350;
            int? WeeksWorked = 52;
            //act
            _repoTemp.Update(1111, "Ben", "Edmondson", null,null,DayRate,WeeksWorked);
            decimal? _DayRate = _repoTemp.employees[0].DayRate;
            int? _WeeksWorked = _repoTemp.employees[0].WeeksWorked;
            //assert
            Assert.That(_DayRate, Is.EqualTo(DayRate));
            Assert.That(_WeeksWorked, Is.EqualTo(WeeksWorked));
        }
        [Test]
        public void AddTest()
        {
            //arrange
            int employeeCounter = _repoTemp.employees.Count() - 1;
            //act
            _repoTemp.AddEmployee("Ben", "Edmondson", null, null, 500, 52);
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(_repoTemp.employees.Count()));
        }
        [Test]
        public void RemoveAllTest()
        {
            Assert.That(_repoTemp.RemoveAll(), Is.EqualTo(true));
        }
        [Test]
        public void RemoveOne()
        {
            Assert.That(_repoTemp.Delete(1111), Is.EqualTo(true));
            Assert.That(_repoTemp.Delete(1112), Is.EqualTo(false));
        }

    }
}
