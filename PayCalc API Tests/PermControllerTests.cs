using Microsoft.AspNetCore.Mvc;
using Moq;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using PayCalcAPI.Controllers;

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


        [Test]
        public void API_Should_Return_Single_Employee_Status_Code_200()
        {
            _mockPermanentRepository
                .Setup(x => x.Read(It.IsAny<int>())).Returns(employees[0]);

            var response = permanentEmployeeController.Get(1111);
            var contentResult = response as OkObjectResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockPermanentRepository
                    .Verify(x => x.Read(1111), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(200));
            });
        }

        [Test]
        public void API_Should_Delete_Employee_Return_Code_204()
        {
            _mockPermanentRepository
                .Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            var response = permanentEmployeeController.Delete(1111);
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockPermanentRepository
                    .Verify(x => x.Delete(1111), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }

        [Test]
        public void API_Should_Delete_All_Employees_Code_204()
        {
            _mockPermanentRepository.Setup(x => x.RemoveAll()).Returns(true);

            var response = permanentEmployeeController.DeleteAll();
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockPermanentRepository
                    .Verify(x => x.RemoveAll(), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }

        [Test]
        public void API_Should_Create_Employee_Code_204()
        {
            _mockPermanentRepository
                .Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>(), null, null))
                .Returns(new PermanentEmployee { ID = 1112, FirstName = "Ben", LastName = "Edmondson", Salary = 50000, Bonus = 5000 });

            var response = permanentEmployeeController.Post("Ben", "Edmondson", 50000, 5000);
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockPermanentRepository
                    .Verify(x => x.Create("Ben", "Edmondson", 50000, 5000, null, null), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }

        [Test]
        public void API_Should_Update_Employee_Code_204()
        {
            _mockPermanentRepository
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>(), null, null))
                .Returns(true);

            var response = permanentEmployeeController.Put(1112, "Ben", "Edmondson", 50000, 5000);
            var contentResult = response as NoContentResult;
            var statusCode = contentResult?.StatusCode;

            Assert.Multiple(() =>
            {
                _mockPermanentRepository
                    .Verify(x => x.Update(1112, "Ben", "Edmondson", 50000, 5000, null, null), Times.Once());
                Assert.IsNotNull(contentResult);
                Assert.That(statusCode, Is.EqualTo(204));
            });
        }
    }
}