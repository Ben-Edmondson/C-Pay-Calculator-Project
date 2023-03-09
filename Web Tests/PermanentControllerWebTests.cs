using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Controllers;
using Web.Models;

namespace Web_Tests
{
    public class PermanentControllerWebTests
    {
        private Mock<IEmployeeRepository<PermanentEmployee>> _mockPermanentRepository;
        private PermanentEmployeeController _employeeController;
        private List<PermanentEmployee> employeesPerm = new List<PermanentEmployee>() {
            new PermanentEmployee(){ ID = 1000, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new PermanentEmployee(){ ID = 1111, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 }};

        [SetUp]
        public void SetUp()
        {
            _mockPermanentRepository = new Mock<IEmployeeRepository<PermanentEmployee>>();
            _employeeController = new PermanentEmployeeController(_mockPermanentRepository.Object);
            _mockPermanentRepository
                .Setup(x => x.ReadAll()).Returns(employeesPerm);
        }

        [Test]
        public void PermanentEmployeeListLoads() 
        {

            var result = _employeeController.EmployeeList() as ViewResult;
            var test = result.ViewData.ModelMetadata.Properties.Count();
            Assert.IsNotNull(result);
            Assert.That(result.Model.ToString(), Is.EqualTo("Web.Models.PermanentEmployeeViewModel"));
            Assert.That(test, Is.EqualTo(employeesPerm.Count()));
        }
    }
}
