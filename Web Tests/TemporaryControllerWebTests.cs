using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Controllers;


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

        [SetUp]
        public void SetUp()
        {
            _mockTemporaryRepository = new Mock<IEmployeeRepository<TemporaryEmployee>>();
            _employeeController = new TemporaryEmployeeController(_mockTemporaryRepository.Object);
            _mockTemporaryRepository
                .Setup(x => x.ReadAll()).Returns(employeesTemp);
        }

        [Test]
        public void TemporaryEmployeeList()
        {
            var result = _employeeController.EmployeeList() as ViewResult;
            var test = result.ViewData.ModelMetadata.Properties.Count();
            Assert.IsNotNull(result);
            Assert.That(result.Model.ToString(), Is.EqualTo("Web.Models.TemporaryEmployeeViewModel"));
            Assert.That(test, Is.EqualTo(1));
        }

        [Test]
        public void AddTemporaryEmployeeTest()
        {
            TemporaryEmployee employee = new TemporaryEmployee()
            {
                FirstName = "Test",
                LastName = "Tester",
                DayRate = 350,
                WeeksWorked = 52,
                ID = 1111
            };
            _mockTemporaryRepository.Setup(x => x.Create("Test","Test",null,null,350,52)).Returns(employee);
            var result = _employeeController.AddEmployee() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateTemporaryEmployeeTest()
        {
            TemporaryEmployee employee = new TemporaryEmployee()
            {
                FirstName = "Test",
                LastName = "Tester",
                DayRate = 350,
                WeeksWorked = 52,
                ID = 1111
            };
            _mockTemporaryRepository.Setup(x => x.Create("Test", "Test", null, null, 350, 52)).Returns(employee);
            var result = _employeeController.AddEmployee() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteTemporaryEmployeeTest()
        {
            TemporaryEmployee employee = new TemporaryEmployee()
            {
                FirstName = "Test",
                LastName = "Tester",
                DayRate = 350,
                WeeksWorked = 52,
                ID = 1111
            };
            _mockTemporaryRepository.Setup(x => x.Delete(1111)).Returns(true);
            var result = _employeeController.DeleteEmployee(1111) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void DetailedTemporaryEmployeeInfoTest()
        {
            TemporaryEmployee employee = new TemporaryEmployee()
            {
                FirstName = "Test",
                LastName = "Tester",
                DayRate = 350,
                WeeksWorked = 52,
                ID = 1111
            };
            _mockTemporaryRepository.Setup(x => x.Read(1111)).Returns(employee);
            var result = _employeeController.ReadEmployee(1111) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
