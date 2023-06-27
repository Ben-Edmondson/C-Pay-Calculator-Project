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
    public class MockedEFCoreTemporaryRepoTests
    {
        Mock<MyDbContext> mockedDbContext;
        List<TemporaryEmployee> employees;
        TemporaryEmployeeRepo tempEmployeeRepo;
        [SetUp]
        public void SetUp()
        {
            employees = new List<TemporaryEmployee>()
            {
                new TemporaryEmployee(){ ID = 1111, FirstName = "Joe", LastName = "Bloggs", DayRate = 450, WeeksWorked = 45, StartDate = new DateTime(2000,8,3) },
                new TemporaryEmployee(){ ID = 2222, FirstName = "John", LastName = "Smith", DayRate = 420, WeeksWorked = 45, StartDate = new DateTime(2000,10,3) }
            };
            mockedDbContext = new Mock<MyDbContext>();

            mockedDbContext.Setup(x => x.TemporaryEmployees).ReturnsDbSet(employees);
            tempEmployeeRepo = new TemporaryEmployeeRepo(mockedDbContext.Object);
        }


        [Test]
        public void Get_Individual_Employee_Test()
        {
            //Arrange
            mockedDbContext.Setup(x => x.TemporaryEmployees.Find(1111)).Returns(employees[0]);

            //Act
            var temporaryEmployee = tempEmployeeRepo.Read(1111);

            //Assert
            Assert.That(temporaryEmployee, Is.EqualTo(employees[0]));
        }

        [Test]
        public void Get_Individual_Employee_Returns_Null()
        {
            //Arrange

            //Act
            var temporaryEmployee = tempEmployeeRepo.Read(0000);
            //Assert
            Assert.That(temporaryEmployee, Is.Null);
        }

        [Test]
        public void Get_Employees_Test()
        {
            //Arrange

            //Act
            var temporaryEmployees = tempEmployeeRepo.ReadAll();

            //Assert
            Assert.That(employees, Is.EqualTo(temporaryEmployees));
        }

        [Test]
        public void Create_Employee_Test()
        {
            //Arrange
            DateTime startDate = DateTime.Now;
            string firstName = "John";
            string lastName = "Doe";
            decimal? dayRate = 250;
            int weeksWorked = 25;

            //Act
            var employee = tempEmployeeRepo.Create(startDate, firstName, lastName, null, null, dayRate, weeksWorked);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(employee.StartDate, Is.EqualTo(startDate));
                Assert.That(employee.FirstName, Is.EqualTo(firstName));
                Assert.That(employee.LastName, Is.EqualTo(lastName));
                Assert.That(employee.WeeksWorked, Is.EqualTo(weeksWorked));
                Assert.That(employee.DayRate, Is.EqualTo(dayRate));
            });
        }
    }
}
