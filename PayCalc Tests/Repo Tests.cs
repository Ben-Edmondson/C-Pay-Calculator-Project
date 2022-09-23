using PayCalc_Project;
using PayCalc_Project.Repository;
using PayCalc_Project.Services;
namespace PayCalc_Tests
{
    [TestFixture]
    public class CRUD_Tests
    {
        EmployeePermRepo _repoPerm = new EmployeePermRepo();
        EmployeeTempRepo _repoTemp = new EmployeeTempRepo();
        [Test]
        public void UpdateTest()
        {
            //arrange
            decimal Sal = 55000;
            decimal Bonus = 5000m;
            decimal TotalAnnual = 60000;
            //act
            _repoPerm.employees[0] = _repoPerm.Update(0, "Ben", "Edmondson", Sal, Bonus, null, null);
            decimal? _Sal = _repoPerm.employees[0].Salary;
            decimal? _Bonus = _repoPerm.employees[0].Bonus;
            decimal? _TotalAnnual = Calculations.TotalAnnualPayPerm(_repoPerm.employees,0);
            //assert
//            Assert.That(_Sal, Is.EqualTo(Sal));
            Assert.That(_Bonus, Is.EqualTo(Bonus));
            Assert.That(_TotalAnnual, Is.EqualTo(TotalAnnual));
        }
    }
}
