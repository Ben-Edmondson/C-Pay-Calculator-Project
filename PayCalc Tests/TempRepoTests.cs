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
            _repoTemp.Update(0, "Ben", "Edmondson", null,null,DayRate,WeeksWorked);
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
            //act
            _repoTemp.RemoveAll();
            int employeeCounter = 0;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(_repoTemp.employees.Count()));
        }
        [Test]
        public void RemoveOne()
        {
            int employeeCounter = _repoTemp.employees.Count();
            _repoTemp.Delete(0);
            employeeCounter = employeeCounter - 1;
            Assert.That(employeeCounter, Is.EqualTo(_repoTemp.employees.Count()));

        }

    }
}
