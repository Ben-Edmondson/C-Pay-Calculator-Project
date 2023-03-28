using PayCalc_Project.Models;
using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class TempRepoTests
    {
        private TemporaryEmployeeRepo _repoTemp = new TemporaryEmployeeRepo();
       
        [SetUp]
        public void Init()
        {
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
            _repoTemp = new TemporaryEmployeeRepo(employeeList);

        }
        [Test]
        public void Temporary_Repo_Can_Update()
        {
            //arrange
            var DayRate = 200;
            var WeeksWorked = 40;
            //act
            _repoTemp.Update(1001, "Ben", "Edmondson", null, null, DayRate, WeeksWorked);
            TemporaryEmployee employeeRead = _repoTemp.Read(1001);
            var _DayRate = employeeRead.DayRate;
            var _WeeksWorked = employeeRead.WeeksWorked;
            //assert
            Assert.That(_DayRate, Is.EqualTo(DayRate));
            Assert.That(_WeeksWorked, Is.EqualTo(WeeksWorked));
        }
        [Test]
        public void Can_Add_To_Temporary_Repo()
        {
            List<TemporaryEmployee> employees = _repoTemp.ReadAll();
            //arrange
            var employeeCounter = employees.Count();
            //act
            TemporaryEmployee createTest = _repoTemp.Create(new DateTime(2000, 1, 1), "Ben", "Edmondson", null, null, 500, 52);
            TemporaryEmployee _createTest = new TemporaryEmployee() {ID = createTest.ID, FirstName = "Ben", LastName = "Edmondson", DayRate = 500, WeeksWorked = 52 };
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(employees.Count()));
            Assert.That(createTest.FirstName, Is.EquivalentTo(_createTest.FirstName));
            Assert.That(createTest.LastName, Is.EquivalentTo(_createTest.LastName));
            Assert.That(createTest.ID, Is.EqualTo(_createTest.ID));
            Assert.That(createTest.DayRate, Is.EqualTo(_createTest.DayRate));
            Assert.That(createTest.WeeksWorked, Is.EqualTo(_createTest.WeeksWorked));
        }
        [Test]
        public void Can_Clear_Temporary_Employees()
        {
            Assert.That(_repoTemp.RemoveAll(), Is.EqualTo(true));
        }
        [Test]
        public void Can_Remove_One_Temporary_Employee_From_List()
        {
            Assert.That(_repoTemp.Delete(1001), Is.EqualTo(true));
            Assert.That(_repoTemp.Delete(1112), Is.EqualTo(false));
        }

    }
}
