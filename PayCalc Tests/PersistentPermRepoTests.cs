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
            _dbContext = new MyDbContext();
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
            Assert.AreEqual(startDate, createdEmployee.StartDate);
            Assert.AreEqual(firstName, createdEmployee.FirstName);
            Assert.AreEqual(lastName, createdEmployee.LastName);
            Assert.AreEqual(salary, createdEmployee.Salary);
            Assert.AreEqual(bonus, createdEmployee.Bonus);
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
            Assert.AreEqual(2, employees.Count);
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
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Doe", result.LastName);
            Assert.AreEqual(5000, result.Salary);
            Assert.AreEqual(1000, result.Bonus);
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
            Assert.AreEqual("UpdatedFirstName", updatedEmployee.FirstName);
            Assert.AreEqual("UpdatedLastName", updatedEmployee.LastName);
            Assert.AreEqual(6000, updatedEmployee.Salary);
            Assert.AreEqual(2000, updatedEmployee.Bonus);
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

