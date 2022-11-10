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

        [Test]
        public void API_Should_Return_Single_Employee_Status_Code_200()
        {
            _mockTemporaryRepository
                .Setup(x => x.Read(It.IsAny<int>())).Returns(employees[0]);

            var response = temporaryEmployeeController.Get(1111);
            var contentResult = response as OkObjectResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Read(1111), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(200));
            });
        }

        [Test]
        public void API_Should_Delete_Employee_Return_Code_204()
        {
            _mockTemporaryRepository
                .Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            var response = temporaryEmployeeController.Delete(1111);
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Delete(1111), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            }
            );
        }
    }
}
