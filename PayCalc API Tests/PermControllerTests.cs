using PayCalc_Project.Repository;
using Moq;
using PayCalc_Project.Models;
using PayCalcAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace PayCalc_API_Tests
{
    public class PermControllerTests
    {
        private List<PermanentEmployee> employees = new List<PermanentEmployee>() {
            new PermanentEmployee(){ ID = 1000, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new PermanentEmployee(){ ID = 1111, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }};

        private Mock<IEmployeeRepository<PermanentEmployee>> _mockPermanentRepository;
        private EmployeePermController permanentEmployeeController;

        [SetUp]
        public void Setup()
        {
            _mockPermanentRepository = new Mock<IEmployeeRepository<PermanentEmployee>>();

            _mockPermanentRepository
                .Setup(x => x.Read(It.IsAny<int>())).Returns(employees[0]);
            _mockPermanentRepository
                .Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            _mockPermanentRepository
                .Setup(x => x.Create("Ben","Edmondson", 50000,5000,null,null))
                .Returns(new PermanentEmployee { ID = 1112, FirstName = "Ben", LastName = "Edmondson", Salary = 50000, Bonus = 5000});
            _mockPermanentRepository.Setup(x => x.RemoveAll());
            permanentEmployeeController = new EmployeePermController(_mockPermanentRepository.Object);
        }

        [Test]
        public void API_Should_Return_All_With_Status200()
        {
            //arrange
            _mockPermanentRepository
                .Setup(x => x.ReadAll()).Returns(employees);
            //act
            var response = permanentEmployeeController.GetAll();
            var contentResult = response as OkObjectResult;
            var statusCode = contentResult?.StatusCode;
            //assert
            Assert.Multiple(() =>
            {
                _mockPermanentRepository
                    .Verify(x => x.ReadAll(), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(200));
            });
        }
    }
}