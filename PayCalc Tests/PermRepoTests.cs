using PayCalc_Project.Models;
using PayCalc_Project.Repository;
namespace PayCalc_Tests
{
    [TestFixture]
    public class PermRepoTests
    {
        [Test]
        public void Permanent_Repo_Can_Update()
        {
            //arrange
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
            var repoPermanentEmployee = new PermanentEmployeeRepo(employeeList);
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
            _repoPerm.Create("Ben", "Edmondson", 25000, 3000, null, null);
            employeeCounter = employeeCounter + 1;
            //assert
            Assert.That(employeeCounter, Is.EqualTo(employees.Count()));
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
            var _repoPerm = new PermanentEmployeeRepo(employeeList);
            Assert.That(_repoPerm.Delete(1001), Is.EqualTo(true));
            Assert.That(_repoPerm.Delete(1111), Is.EqualTo(false));

        }
    }
}
