using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Controllers;
using Web.Models;

namespace Web_Tests
{
    public class TemporaryControllerWebTests
    {
        private Mock<IEmployeeRepository<TemporaryEmployee>> _mockTemporaryRepository;
        private TemporaryEmployeeController _employeeController;
        private List<TemporaryEmployee> employeesTemp = new List<TemporaryEmployee>()
        {
            new TemporaryEmployee() { ID = 1111, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };
        TemporaryEmployee employee;

        [SetUp]
        public void SetUp()
        {
            employee = new TemporaryEmployee()
            {
                FirstName = "Test",
                LastName = "Tester",
                DayRate = 350,
                WeeksWorked = 52,
                ID = 1111
            };

            _mockTemporaryRepository = new Mock<IEmployeeRepository<TemporaryEmployee>>();
            _employeeController = new TemporaryEmployeeController(_mockTemporaryRepository.Object);

            _mockTemporaryRepository
                .Setup(x => x.ReadAll())
                .Returns(employeesTemp);
            _mockTemporaryRepository
                .Setup(x => x.Read(1111))
                .Returns(employee);
        }


        [Test]
        public void TemporaryEmployeeLoadsList()
        {
            var result = _employeeController.EmployeeList() as ViewResult;
            var test = ((TemporaryEmployeeViewModel)((ViewResult)result).Model).TemporaryEmployees.Count();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model.ToString(), Is.EqualTo("Web.Models.TemporaryEmployeeViewModel"));
            Assert.That(test, Is.EqualTo(1));
        }

        [Test]
        public void AddTemporaryEmployeeLoadsTest()
        {
            _mockTemporaryRepository
                .Setup(x => x.Create("Test","Test",null,null,350,52))
                .Returns(employee);
            var result = _employeeController.AddEmployee() as ViewResult;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void UpdateTemporaryEmployeeLoadsTest()
        {
            _mockTemporaryRepository
                .Setup(x => x.Update(1111, "Test", "Test", null, null, 350, 52))
                .Returns(true);
            var result = _employeeController.UpdateEmployee(1111) as ViewResult;
            var testData = ((TemporaryEmployee)((ViewResult)result).Model).FirstName;
            Assert.That(result, Is.Not.Null);
            Assert.That(testData, Is.EqualTo("Test"));
        }

        [Test]
        public void DeleteTemporaryEmployeeTest()
        {
            _mockTemporaryRepository
                .Setup(x => x.Delete(1111))
                .Returns(true);
            var result = _employeeController.DeleteEmployee(1111) as RedirectToActionResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("EmployeeList"));
        }

        [Test]
        public void DetailedTemporaryEmployeeInfoLoadsTest()
        {
            var result = _employeeController.ReadEmployee(1111) as ViewResult;
            var testData = ((TemporaryEmployee)((ViewResult)result).Model).FirstName;
            Assert.That(result, Is.Not.Null);
            Assert.That(testData, Is.EqualTo("Test"));
        }
    }
}
