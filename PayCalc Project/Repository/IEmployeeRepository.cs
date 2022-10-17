namespace PayCalc_Project.Repository
{
    public interface IEmployeeRepository<T>
    {
        public T Create(string firstName, string lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked);
        public void AddEmployee(T employee);
        public List<T> ReadAll();
        public T? ReadSingle(int id);
        public bool Update(int id, string? firstName, string? lastName, decimal? salary, decimal? bonus, decimal? dayRate, int? weeksWorked);
        public bool Delete(int id);
        public bool RemoveAll();
    }
}
