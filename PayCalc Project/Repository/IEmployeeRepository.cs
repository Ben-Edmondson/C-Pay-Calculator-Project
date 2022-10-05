namespace PayCalc_Project.Repository
{
    public interface IEmployeeRepository<T>
    {
        public T AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked);
        public List<T> ReadAll();
        public T ReadSingle(int i);
        public T Update(int i, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked);
        public bool Delete(int i);
        public bool RemoveAll();

    }
}
