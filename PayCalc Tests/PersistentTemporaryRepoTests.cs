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
            Assert.AreEqual(startDate, createdEmployee.StartDate);
            Assert.AreEqual(firstName, createdEmployee.FirstName);
            Assert.AreEqual(lastName, createdEmployee.LastName);
            Assert.AreEqual(dayRate, createdEmployee.DayRate);
            Assert.AreEqual(weeksWorked, createdEmployee.WeeksWorked);
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
            Assert.AreEqual(2, employees.Count);
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
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Doe", result.LastName);
            Assert.AreEqual(100, result.DayRate);
            Assert.AreEqual(4, result.WeeksWorked);
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
            Assert.AreEqual("UpdatedFirstName", updatedEmployee.FirstName);
            Assert.AreEqual("UpdatedLastName", updatedEmployee.LastName);
            Assert.AreEqual(120, updatedEmployee.DayRate);
            Assert.AreEqual(3, updatedEmployee.WeeksWorked);
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
