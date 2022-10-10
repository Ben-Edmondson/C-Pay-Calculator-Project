namespace PayCalc_Project.Repository
{
    public interface IEmployeeRepository<T>
    {
        public T AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked);
        public List<T> ReadAll();
        public T? ReadSingle(int id);
        public void Update(int id, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked);
        public bool Delete(int id);
        public bool RemoveAll();

    }
}
