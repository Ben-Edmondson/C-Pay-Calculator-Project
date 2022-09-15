using PayCalc_Project;
namespace PayCalc_Tests
{
    [TestFixture]
    public class CRUD_Tests
    {
        CRUD _repo = new CRUD();
        [Test]
        public void UpdateTest()
        {
            //arrange
            decimal Sal = 55000;
            decimal Bonus = 5000m;
            decimal TotalAnnual = 60000;
            //act
            _repo.UpdatePerm(0,"Ben", "Edmondson",Sal,Bonus);
            decimal _Sal = _repo.employees[0].Salary;
            decimal _Bonus = _repo.employees[0].Bonus;
            decimal _TotalAnnual = Calculations.TotalAnnualPay(_repo.employees,0);
            //assert
            Assert.That(_Sal, Is.EqualTo(Sal));
            Assert.That(_Bonus, Is.EqualTo(Bonus));
            Assert.That(_TotalAnnual, Is.EqualTo(TotalAnnual));
        }
    }
}
