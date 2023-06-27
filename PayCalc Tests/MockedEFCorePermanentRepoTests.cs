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
        PermanentEmployeeRepo permEmployeeRepo;
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
            permEmployeeRepo = new PermanentEmployeeRepo(mockedDbContext.Object);
        }


        [Test]
        public void Get_Individual_Employee_Test()
        {
            //Arrange

            //Act
            var permanentEmployee = permEmployeeRepo.Read(1111);

            //Assert
            Assert.That(permanentEmployee, Is.EqualTo(employees[0]));
        }

        [Test]
        public void Get_Employees_Test()
        {
            //Arrange
            
            //Act
            var permanentEmployees = permEmployeeRepo.ReadAll();

            //Assert
            Assert.That(employees, Is.EqualTo(permanentEmployees));
        }

        [Test]
        public void Create_Employee_Test()
        {
            //Arrange
            DateTime startDate = DateTime.Now;
            string firstName = "John";
            string lastName = "Doe";
            decimal? salary = 5000;
            decimal? bonus = 1000;

            //Act
            var employee = permEmployeeRepo.Create(startDate, firstName, lastName, salary, bonus, null, null);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(employee.StartDate, Is.EqualTo(startDate));
                Assert.That(employee.FirstName, Is.EqualTo(firstName));
                Assert.That(employee.LastName, Is.EqualTo(lastName));
                Assert.That(employee.Salary, Is.EqualTo(salary));
                Assert.That(employee.Bonus, Is.EqualTo(bonus));
            });
        }
    }
}
