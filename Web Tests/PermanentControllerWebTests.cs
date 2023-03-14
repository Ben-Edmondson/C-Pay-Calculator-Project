﻿using Microsoft.AspNetCore.Mvc;
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
        
        PermanentEmployee employee;

        [SetUp]
        public void SetUp()
        {
            _mockPermanentRepository = new Mock<IEmployeeRepository<PermanentEmployee>>();
            _employeeController = new PermanentEmployeeController(_mockPermanentRepository.Object);
            _mockPermanentRepository
                .Setup(x => x.ReadAll())
                .Returns(employeesPerm);
            employee = new PermanentEmployee()
            {
                FirstName = "Test",
                LastName = "Tester",
                Salary = 50000,
                Bonus = 5200,
                ID = 1111
            };
        }

        [Test]
        public void PermanentEmployeeListLoads() 
        {

            var result = _employeeController.EmployeeList() as ViewResult;
            var test = ((PermanentEmployeeViewModel)((ViewResult)result).Model).PermanentEmployees.Count();
            Assert.IsNotNull(result);
            Assert.That(result.Model.ToString(), Is.EqualTo("Web.Models.PermanentEmployeeViewModel"));
            Assert.That(test, Is.EqualTo(2));
        }
        [Test]
        public void AddPermanentEmployeeTest()
        {

            _mockPermanentRepository
                .Setup(x => x.Create("Test", "Test", null, null, 350, 52))
                .Returns(employee);
            var result = _employeeController.AddEmployee() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdatePermanentEmployeeTest()
        {
            _mockPermanentRepository
                .Setup(x => x.Update(1111, "Test", "Test", null, null, 350, 52))
                .Returns(true);
            var result = _employeeController.UpdateEmployee(1111) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeletePermanentEmployeeTest()
        {
            _mockPermanentRepository
                .Setup(x => x.Delete(1111))
                .Returns(true);
            var result = _employeeController.DeleteEmployee(1111) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void DetailedPermanentEmployeeInfoTest()
        {
            _mockPermanentRepository
                .Setup(x => x.Read(1111))
                .Returns(employee);
            var result = _employeeController.ReadEmployee(1111) as ViewResult;
            var testData = ((PermanentEmployee)((ViewResult)result).Model).FirstName;
            Assert.IsNotNull(result);
            Assert.That(testData, Is.EqualTo("Test"));
        }
    }
}
