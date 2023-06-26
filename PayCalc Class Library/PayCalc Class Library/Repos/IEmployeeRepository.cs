namespace PayCalc.ClassLibrary.Repos
{
    public interface IEmployeeRepository<T>
    {
        public T Create(DateTime startDate, string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked);
        public List<T> ReadAll();
        public T? Read(int id);
        public bool Update(int id, string? firstName, string? lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked);
        public bool Delete(int id);
        public bool RemoveAll();
    }
}
