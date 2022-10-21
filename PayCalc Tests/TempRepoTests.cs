using PayCalc_Project.Models;
using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class TempRepoTests
    {
        TemporaryEmployeeRepo _repoTemp = new TemporaryEmployeeRepo();
        [Test]
        public void Temporary_Repo_Can_Update()
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
        public void Can_Add_To_Temporary_Repo()
        {
            List<TemporaryEmployee> employees = _repoTemp.ReadAll();
            //arrange
            int employeeCounter = employees.Count() - 1;
            //act
            _repoTemp.Create("Ben", "Edmondson", null, null, 500, 52);
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(employees.Count()));
        }
        [Test]
        public void Can_Clear_Temporary_Employees()
        {
            Assert.That(_repoTemp.RemoveAll(), Is.EqualTo(true));
        }
        [Test]
        public void Can_Remove_One_Temporary_Employee_From_List()
        {
            Assert.That(_repoTemp.Delete(1111), Is.EqualTo(true));
            Assert.That(_repoTemp.Delete(1112), Is.EqualTo(false));
        }

    }
}
