using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework.Constraints;
using PayCalc.ClassLibrary.dbContext;
using PayCalc.ClassLibrary.Models;
using PayCalc.ClassLibrary.Repos.Persistent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Tests
{

    [TestFixture]
    public class MockedEFCorePermanentRepoTests
    {
        Mock<MyDbContext> mockedDbContext;
        List<PermanentEmployee> employees;
        [SetUp]
        public void SetUp()
        {
            employees = new List<PermanentEmployee>()
            {
                new PermanentEmployee(){ ID = 1111, FirstName = "Joe", LastName = "Bloggs", Salary = 40000.00m, Bonus = 5000.00m, StartDate = new DateTime(2000,8,3) },
                new PermanentEmployee(){ ID = 2222, FirstName = "John", LastName = "Smith", Salary = 45000.00m, Bonus = 2500.00m, StartDate = new DateTime(2000,10,3) }
            };
            mockedDbContext = new Mock<MyDbContext>();

            mockedDbContext.Setup(x => x.PermanentEmployees).ReturnsDbSet(employees);
        }


        [Test]
        public void Create_New_Employee_Test()
        {

        }

        [Test]
        public void Get_Employees_Test()
        {
            //Arrange
            var permEmployeeRepo = new PermanentEmployeeRepo(mockedDbContext.Object);

            //Act
            var permanentEmployees = permEmployeeRepo.ReadAll();

            //Assert
            Assert.That(employees, Is.EqualTo(permanentEmployees));
        }
    }
}
