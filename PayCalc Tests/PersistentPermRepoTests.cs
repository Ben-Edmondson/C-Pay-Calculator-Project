using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PayCalc.ClassLibrary.dbContext;
using PayCalc.ClassLibrary.Models;
using PayCalc.ClassLibrary.Repos.Persistent;

namespace PayCalc_Project.Tests
{
    [TestFixture]
    public class PersistentPermRepoTests
    {
        private MyDbContext _dbContext;
        private PermanentEmployeeRepo _employeeRepo;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _dbContext = new MyDbContext(options, useInMemory: true);
            _employeeRepo = new PermanentEmployeeRepo(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the database after each test
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_WhenCalled_CreatesPermanentEmployee()
        {
            // Arrange
            DateTime startDate = DateTime.Now;
            string firstName = "John";
            string lastName = "Doe";
            decimal? salary = 5000;
            decimal? bonus = 1000;

            // Act
            PermanentEmployee createdEmployee = _employeeRepo.Create(startDate, firstName, lastName, salary, bonus, null, null);

            // Assert
            Assert.IsNotNull(createdEmployee);
            Assert.That(createdEmployee.StartDate, Is.EqualTo(startDate));
            Assert.That(createdEmployee.FirstName, Is.EqualTo(firstName));
            Assert.That(createdEmployee.LastName, Is.EqualTo(lastName));
            Assert.That(createdEmployee.Salary, Is.EqualTo(salary));
            Assert.That(createdEmployee.Bonus, Is.EqualTo(bonus));
        }

        [Test]
        public void ReadAll_WhenEmployeesExist_ReturnsAllPermanentEmployees()
        {
            // Arrange
            var employee1 = new PermanentEmployee() { FirstName = "John", LastName = "Doe", Salary = 5000, Bonus = 1000 };
            var employee2 = new PermanentEmployee() { FirstName = "Jane", LastName = "Smith", Salary = 6000, Bonus = 1500 };
            _dbContext.PermanentEmployees.AddRange(employee1, employee2);
            _dbContext.SaveChanges();

            // Act
            var employees = _employeeRepo.ReadAll();

            // Assert
            Assert.That(employees.Count, Is.EqualTo(2));
            Assert.IsTrue(employees.Any(e => e.FirstName == "John" && e.LastName == "Doe"));
            Assert.IsTrue(employees.Any(e => e.FirstName == "Jane" && e.LastName == "Smith"));
        }

        [Test]
        public void Read_WithExistingId_ReturnsPermanentEmployee()
        {
            // Arrange
            var employee = new PermanentEmployee() { FirstName = "John", LastName = "Doe", Salary = 5000, Bonus = 1000 };
            _dbContext.PermanentEmployees.Add(employee);
            _dbContext.SaveChanges();

            // Act
            var result = _employeeRepo.Read(employee.ID);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.Salary, Is.EqualTo(5000));
            Assert.That(result.Bonus, Is.EqualTo(1000));
        }

        [Test]
        public void Update_WithExistingId_UpdatesPermanentEmployee()
        {
            // Arrange
            var employee = new PermanentEmployee() { FirstName = "John", LastName = "Doe", Salary = 5000, Bonus = 1000 };
            _dbContext.PermanentEmployees.Add(employee);
            _dbContext.SaveChanges();

            // Act
            bool result = _employeeRepo.Update(employee.ID, "UpdatedFirstName", "UpdatedLastName", 6000, 2000, null, null);
            var updatedEmployee = _employeeRepo.Read(employee.ID);

            // Assert
            Assert.IsTrue(result);
            Assert.That(updatedEmployee.FirstName, Is.EqualTo("UpdatedFirstName"));
            Assert.That(updatedEmployee.LastName, Is.EqualTo("UpdatedLastName"));
            Assert.That(updatedEmployee.Salary, Is.EqualTo(6000));
            Assert.That(updatedEmployee.Bonus, Is.EqualTo(2000));
        }

        [Test]
        public void Delete_WithExistingId_DeletesPermanentEmployee()
        {
            // Arrange
            var employee = new PermanentEmployee() { FirstName = "John", LastName = "Doe", Salary = 5000, Bonus = 1000 };
            _dbContext.PermanentEmployees.Add(employee);
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

