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
            //act
            var result = _employeeController.EmployeeList() as ViewResult;
            var test = ((TemporaryEmployeeViewModel)result.Model).TemporaryEmployees.Count();
            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model.ToString(), Is.EqualTo("Web.Models.TemporaryEmployeeViewModel"));
            Assert.That(test, Is.EqualTo(1));
        }

        [Test]
        public void AddTemporaryEmployeeLoadsTest()
        {
            //act   
            var result = _employeeController.AddEmployee() as ViewResult;
            //assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void UpdateTemporaryEmployeeLoadsTest()
        {
            //act
            var result = _employeeController.UpdateEmployee(1111) as ViewResult;
            var testData = ((TemporaryEmployee)result.Model).FirstName;
            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(testData, Is.EqualTo("Test"));
        }

        [Test]
        public void DeleteTemporaryEmployeeTest()
        {
            _mockTemporaryRepository
                .Setup(x => x.Delete(1111))
                .Returns(true);
            //act
            var result = _employeeController.DeleteEmployee(1111) as RedirectToActionResult;
            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("EmployeeListDeleteConfirmed"));
        }

        [Test]
        public void DetailedTemporaryEmployeeInfoLoadsTest()
        {
            //act
            var result = _employeeController.ReadEmployee(1111) as ViewResult;
            var testData = ((DetailedTemporaryEmployeeViewModel)result.Model).Employee.FirstName;
            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(testData, Is.EqualTo("Test"));
        }

        [Test]
        public void EmployeeAddedAndPageRedirects()
        {
            //arrange
            _mockTemporaryRepository
                .Setup(x => x.Create(new DateTime(2000, 1, 1), "Test", "Test", null, null, 350, 52))
                .Returns(employee);
            //act
            var result = _employeeController.AddEmployee(employee) as RedirectToActionResult;
            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("EmployeeList"));
        }

        [Test]
        public void EmployeeUpdatedAndPageRedirects()
        {
            //arrange
            _mockTemporaryRepository
                .Setup(x => x.Update(1111, "Test", "Test", null, null, 350, 52))
                .Returns(true);
            //act
            var result = _employeeController.UpdateEmployee(employee) as RedirectToActionResult;
            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("EmployeeList"));
        }
    }
}
