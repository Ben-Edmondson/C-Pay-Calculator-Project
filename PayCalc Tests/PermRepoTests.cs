using PayCalc_Project.Models;
using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class PermRepoTests
    {
        private PermanentEmployeeRepo repoPermanentEmployee = new PermanentEmployeeRepo();
        [SetUp]
        public void Init()
        {
            PermanentEmployee employee = new PermanentEmployee()
            {
                ID = 1001,
                FirstName = "Steven",
                LastName = "Tester",
                Salary = 25000,
                Bonus = 5000
            };
            List<PermanentEmployee> employeeList = new List<PermanentEmployee>();
            employeeList.Add(employee);
            repoPermanentEmployee = new PermanentEmployeeRepo(employeeList);
        }
        [Test]
        public void Permanent_Repo_Can_Update()
        {
            //arrange

            var Sal = 25000M;
            var Bonus = 5000m;
            //act
            PermanentEmployee employeeRead = repoPermanentEmployee.Read(1001);
            repoPermanentEmployee.Update(1001, "Ben", "Edmondson", Sal, Bonus, null, null);
            var _Sal = employeeRead.Salary;
            var _Bonus = employeeRead.Bonus;
            //assert
            Assert.That(_Sal, Is.EqualTo(Sal));
            Assert.That(_Bonus, Is.EqualTo(Bonus));
        }

        [Test]
        public void Can_Add_To_Permanent_Repo()
        {
            var _repoPerm = new PermanentEmployeeRepo();
            List<PermanentEmployee> employees = _repoPerm.ReadAll();
            //arrange
            var employeeCounter = employees.Count();
            //act
            PermanentEmployee createTest = _repoPerm.Create(new DateTime(2000, 1, 1), "Ben", "Edmondson", 25000, 3000, null, null);
            PermanentEmployee _createTest = new PermanentEmployee() { ID = createTest.ID, FirstName = "Ben", LastName = "Edmondson", Salary = 25000, Bonus = 3000 };
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(employees.Count()));
            Assert.That(createTest.FirstName, Is.EquivalentTo(_createTest.FirstName));
            Assert.That(createTest.LastName, Is.EquivalentTo(_createTest.LastName));
            Assert.That(createTest.ID, Is.EqualTo(_createTest.ID));
            Assert.That(createTest.Salary, Is.EqualTo(_createTest.Salary));
            Assert.That(createTest.Bonus, Is.EqualTo(_createTest.Bonus));
        }
        [Test]
        public void Can_Clear_Permanent_Employees()
        {
            var _repoPerm = new PermanentEmployeeRepo();
            Assert.That(_repoPerm.RemoveAll(), Is.EqualTo(true));
        }
        [Test]
        public void Can_Remove_One_Permanent_Employee_From_List()
        {
            Assert.That(repoPermanentEmployee.Delete(1001), Is.EqualTo(true));
            Assert.That(repoPermanentEmployee.Delete(1111), Is.EqualTo(false));

        }

        [Test]
        public void Can_Read_Single_Emp()
        {
            var readSingle = repoPermanentEmployee.Read(1001);
            Assert.That(readSingle, Is.Not.Null);
        }

        [Test]
        public void No_Employee_To_Read()
        {
            var readSingle = repoPermanentEmployee.Read(1000);
            Assert.That(readSingle, Is.Null);
        }
    }
}
