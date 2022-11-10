using Microsoft.AspNetCore.Mvc;
using Moq;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalcAPI.Controllers;

namespace PayCalc_API_Tests
{
    class TempControllerTests
    {
        private List<TemporaryEmployee> employees = new List<TemporaryEmployee>()
        {
            new TemporaryEmployee() { ID = 1111, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };

        private Mock<IEmployeeRepository<TemporaryEmployee>> _mockTemporaryRepository;
        private EmployeeTempController temporaryEmployeeController;
        [SetUp]
        public void Setup()
        {
            _mockTemporaryRepository = new Mock<IEmployeeRepository<TemporaryEmployee>>();
            temporaryEmployeeController = new EmployeeTempController(_mockTemporaryRepository.Object);
        }

        [Test]
        public void API_Should_Return_All_With_Status_Code200()
        {
            //arrange
            _mockTemporaryRepository
                .Setup(x => x.ReadAll()).Returns(employees);
            //act
            var response = temporaryEmployeeController.GetAll();
            var contentResult = response as OkObjectResult;
            var statusCode = contentResult?.StatusCode;
            //assert
            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.ReadAll(), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(200));
            });
        }
    }
}
