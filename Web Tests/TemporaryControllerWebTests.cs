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
    }
}
