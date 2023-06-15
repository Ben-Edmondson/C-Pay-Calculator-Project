using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Controllers;

namespace Web_Tests
{
    public class HomeControllerWebTests
    {
        private List<PermanentEmployee> employeesPerm = new List<PermanentEmployee>() {
            new PermanentEmployee(){ ID = 1000, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new PermanentEmployee(){ ID = 1111, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }};
        private List<TemporaryEmployee> employeesTemp = new List<TemporaryEmployee>()
        {
            new TemporaryEmployee() { ID = 1111, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };
        private HomeController controller;
        private Mock<IEmployeeRepository<TemporaryEmployee>> _mockTemporaryRepository;
        private Mock<IEmployeeRepository<PermanentEmployee>> _mockPermanentRepository;

        [SetUp]
        public void Setup()
        {
            _mockTemporaryRepository = new Mock<IEmployeeRepository<TemporaryEmployee>>();
            _mockPermanentRepository = new Mock<IEmployeeRepository<PermanentEmployee>>();
            controller = new HomeController(_mockPermanentRepository.Object, _mockTemporaryRepository.Object);
            _mockTemporaryRepository
                .Setup(x => x.ReadAll()).Returns(employeesTemp);
            _mockPermanentRepository
                .Setup(x => x.ReadAll()).Returns(employeesPerm);
        }

        [Test]
        public void IndexPageLoadTest()
        {
            var result = controller.Index() as ViewResult;
            var test = result.ViewData.ModelMetadata.Properties.Count();
            Assert.IsNotNull(result);
            Assert.Multiple(() =>
            {
                Assert.That(result.Model.ToString(), Is.EqualTo("Web.Models.HomeViewModel"));
                Assert.That(test, Is.EqualTo(2));
            });
        }
    }
}