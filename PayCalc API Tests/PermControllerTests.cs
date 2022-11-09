using PayCalc_Project.Repository;
using Moq;
using PayCalc_Project.Models;
using PayCalcAPI;
using PayCalcAPI.Controllers;

namespace PayCalc_API_Tests
{
    public class PermControllerTests
    {
        List<PermanentEmployee> employees = new List<PermanentEmployee>() {
            new PermanentEmployee(){ ID = 1000, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new PermanentEmployee(){ ID = 1111, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }};

        Mock<IEmployeeRepository<PermanentEmployee>> _mockPermanentRepository = new Mock<IEmployeeRepository<PermanentEmployee>>();

        [SetUp]
        public void Setup()
        {

            _mockPermanentRepository.Setup(x => x.ReadAll()).Returns(employees);
            _mockPermanentRepository.Setup(x => x.Read(
                It.IsAny<int>())).Returns((int i) => employees.Where(
                x => x.ID == i).Single());
            _mockPermanentRepository.Setup(x => x.Delete(1111)).Returns(true);
            _mockPermanentRepository.Setup(x => x.Create());
            _mockPermanentRepository.Setup(x => x.Update());
            _mockPermanentRepository.Setup(x => x.RemoveAll());
            EmployeePermController permController = new EmployeePermController(mockPermanentRepository);
        }

        [Test]
        public void API_Should_Return_All()
        {
            
            Assert.Fail();
        }
    }
}