using NUnit.Framework;
using PayCalc.ClassLibrary.dbContext;
using PayCalc.ClassLibrary.Repos.Persistent;
using PayCalc.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace PayCalc_Project.Tests
{
    [TestFixture]
    public class PersistentTemporaryRepoTests
    {
        private MyDbContext _dbContext;
        private TemporaryEmployeeRepo _employeeRepo;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _dbContext = new MyDbContext(options, useInMemory: true);
            _employeeRepo = new TemporaryEmployeeRepo(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the database after each test
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_WhenCalled_CreatesTemporaryEmployee()
        {
            // Arrange
            DateTime startDate = DateTime.Now;
            string firstName = "John";
            string lastName = "Doe";
            decimal? dayRate = 100;
            int? weeksWorked = 4;

            // Act
            TemporaryEmployee createdEmployee = _employeeRepo.Create(startDate, firstName, lastName, null, null, dayRate, weeksWorked);

            // Assert
            Assert.IsNotNull(createdEmployee);
            Assert.That(createdEmployee.StartDate, Is.EqualTo(startDate));
            Assert.That(createdEmployee.FirstName, Is.EqualTo(firstName));
            Assert.That(createdEmployee.LastName, Is.EqualTo(lastName));
            Assert.That(createdEmployee.DayRate, Is.EqualTo(dayRate));
            Assert.That(createdEmployee.WeeksWorked, Is.EqualTo(weeksWorked));
        }

        [Test]
        public void ReadAll_WhenEmployeesExist_ReturnsAllTemporaryEmployees()
        {
            // Arrange
            var employee1 = new TemporaryEmployee() { FirstName = "John", LastName = "Doe", DayRate = 100, WeeksWorked = 4 };
            var employee2 = new TemporaryEmployee() { FirstName = "Jane", LastName = "Smith", DayRate = 120, WeeksWorked = 3 };
            _dbContext.TemporaryEmployees.AddRange(employee1, employee2);
            _dbContext.SaveChanges();

            // Act
            var employees = _employeeRepo.ReadAll();

            // Assert
            Assert.That(employees.Count, Is.EqualTo(2));
            Assert.IsTrue(employees.Any(e => e.FirstName == "John" && e.LastName == "Doe"));
            Assert.IsTrue(employees.Any(e => e.FirstName == "Jane" && e.LastName == "Smith"));
        }

        [Test]
        public void Read_WithExistingId_ReturnsTemporaryEmployee()
        {
            // Arrange
            var employee = new TemporaryEmployee() { FirstName = "John", LastName = "Doe", DayRate = 100, WeeksWorked = 4 };
            _dbContext.TemporaryEmployees.Add(employee);
            _dbContext.SaveChanges();

            // Act
            var result = _employeeRepo.Read(employee.ID);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.DayRate, Is.EqualTo(100));
            Assert.That(result.WeeksWorked, Is.EqualTo(4));
        }

        [Test]
        public void Update_WithExistingId_UpdatesTemporaryEmployee()
        {
            // Arrange
            var employee = new TemporaryEmployee() { FirstName = "John", LastName = "Doe", DayRate = 100, WeeksWorked = 4 };
            _dbContext.TemporaryEmployees.Add(employee);
            _dbContext.SaveChanges();

            // Act
            bool result = _employeeRepo.Update(employee.ID, "UpdatedFirstName", "UpdatedLastName", null, null, 120, 3);
            var updatedEmployee = _employeeRepo.Read(employee.ID);

            // Assert
            Assert.IsTrue(result);
            Assert.That(updatedEmployee.FirstName, Is.EqualTo("UpdatedFirstName"));
            Assert.That(updatedEmployee.LastName, Is.EqualTo("UpdatedLastName"));
            Assert.That(updatedEmployee.DayRate, Is.EqualTo(120));
            Assert.That(updatedEmployee.WeeksWorked, Is.EqualTo(3));
        }

        [Test]
        public void Delete_WithExistingId_DeletesTemporaryEmployee()
        {
            // Arrange
            var employee = new TemporaryEmployee() { FirstName = "John", LastName = "Doe", DayRate = 100, WeeksWorked = 4 };
            _dbContext.TemporaryEmployees.Add(employee);
            _dbContext.SaveChanges();

            // Act
            bool result = _employeeRepo.Delete(employee.ID);
            var deletedEmployee = _employeeRepo.Read(employee.ID);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(deletedEmployee);
        }

        [Test]
        public void Delete_WithNonExistingId_ReturnsFalse()
        {
            // Arrange
            int nonExistingId = 999;

            // Act
            bool result = _employeeRepo.Delete(nonExistingId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
