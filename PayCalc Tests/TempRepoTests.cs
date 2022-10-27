using PayCalc_Project.Models;
using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class TempRepoTests
    {
        [Test]
        public void Temporary_Repo_Can_Update()
        {
            //arrange
            decimal? DayRate = 200;
            int? WeeksWorked = 40;
            TemporaryEmployee employee = new TemporaryEmployee()
            {
                ID = 1001,
                FirstName = "Steven",
                LastName = "Tester",
                DayRate = 350,
                WeeksWorked = 52
            };
            List<TemporaryEmployee> employeeList = new List<TemporaryEmployee>();
            employeeList.Add(employee);
            var _repoTemp = new TemporaryEmployeeRepo(employeeList);
            //act
            _repoTemp.Update(1001, "Ben", "Edmondson", null,null,DayRate,WeeksWorked);
            TemporaryEmployee employeeRead = _repoTemp.Read(1001);
            decimal? _DayRate = employeeRead.DayRate;
            int? _WeeksWorked = employeeRead.WeeksWorked;
            //assert
            Assert.That(_DayRate, Is.EqualTo(DayRate));
            Assert.That(_WeeksWorked, Is.EqualTo(WeeksWorked));
        }
        [Test]
        public void Can_Add_To_Temporary_Repo()
        {
            TemporaryEmployeeRepo _repoTemp = new TemporaryEmployeeRepo();
            List<TemporaryEmployee> employees = _repoTemp.ReadAll();
            //arrange
            int employeeCounter = employees.Count();
            //act
            _repoTemp.Create("Ben", "Edmondson", null, null, 500, 52);
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(employees.Count()));
        }
        [Test]
        public void Can_Clear_Temporary_Employees()
        {
            TemporaryEmployeeRepo _repoTemp = new TemporaryEmployeeRepo();
            Assert.That(_repoTemp.RemoveAll(), Is.EqualTo(true));
        }
        [Test]
        public void Can_Remove_One_Temporary_Employee_From_List()
        {
            TemporaryEmployee employee = new TemporaryEmployee()
            {
                ID = 1001,
                FirstName = "Steven",
                LastName = "Tester",
                DayRate = 200,
                WeeksWorked = 52
            };
            List<TemporaryEmployee> employeeList = new List<TemporaryEmployee>();
            employeeList.Add(employee);
            TemporaryEmployeeRepo _repoTemp = new TemporaryEmployeeRepo(employeeList);
            Assert.That(_repoTemp.Delete(1001), Is.EqualTo(true));
            Assert.That(_repoTemp.Delete(1112), Is.EqualTo(false));
        }

    }
}
