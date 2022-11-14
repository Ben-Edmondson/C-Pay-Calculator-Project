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
            int employeeID = 1111;

            _mockTemporaryRepository
                .Setup(x => x.Read(employeeID)).Returns(employees[0]);

            var response = temporaryEmployeeController.Get(employeeID);
            var contentResult = response as OkObjectResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Read(employeeID), Times.Once());
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
            });
        }

        [Test]
        public void API_Should_Delete_All_Employees_Code_204()
        {
            _mockTemporaryRepository.Setup(x => x.RemoveAll()).Returns(true);

            var response = temporaryEmployeeController.DeleteAll();
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.RemoveAll(), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }

        [Test]
        public void API_Should_Create_Employee_Code_204()
        {
            _mockTemporaryRepository
                .Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), null, null, It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(new TemporaryEmployee { ID = 1112, FirstName = "Ben", LastName = "Edmondson", DayRate = 350, WeeksWorked = 52 });

            var response = temporaryEmployeeController.Post("Ben", "Edmondson", 350,52);
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Create("Ben", "Edmondson", null, null, 350, 52), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }

        [Test]
        public void API_Should_Update_Employee_Code_204()
        {
            _mockTemporaryRepository
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), null, null, It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(true);

            var response = temporaryEmployeeController.Put(1112, "Ben", "Edmondson", 500, 35);
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Update(1112, "Ben", "Edmondson", null, null, 500, 35), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }

        [Test]
        public void API_Should_Return_All_With_Status_Code404()
        {
            //arrange
            employees.Clear();
            _mockTemporaryRepository
                .Setup(x => x.ReadAll()).Returns(employees);
            //act
            var response = temporaryEmployeeController.GetAll();
            var contentResult = response as NotFoundResult;
            var statusCode = contentResult?.StatusCode;
            //assert
            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.ReadAll(), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(404));
            });
        }

        [Test]
        public void API_Should_Delete_Employee_Return_Code_404()
        {
            _mockTemporaryRepository
                .Setup(x => x.Delete(It.IsAny<int>())).Returns(false);

            var response = temporaryEmployeeController.Delete(1111);
            var contentResult = response as NotFoundResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Delete(1111), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(404));
            });
        }

        [Test]
        public void API_Should_Delete_All_Employees_Code_404()
        {
            _mockTemporaryRepository.Setup(x => x.RemoveAll()).Returns(false);

            var response = temporaryEmployeeController.DeleteAll();
            var contentResult = response as NotFoundResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.RemoveAll(), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(404));
            });
        }

        [Test]
        public void API_Should_Update_Employee_Code_404()
        {
            _mockTemporaryRepository
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), null, null, It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(false);

            var response = temporaryEmployeeController.Put(1112, "Ben", "Edmondson", 500, 35);
            var contentResult = response as NotFoundResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockTemporaryRepository
                    .Verify(x => x.Update(1112, "Ben", "Edmondson", null, null, 500, 35), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(404));
            });
        }
    }
}
