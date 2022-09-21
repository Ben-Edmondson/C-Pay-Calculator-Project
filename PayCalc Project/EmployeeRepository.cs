namespace PayCalc_Project
{
    public interface EmployeeRepository
    {

        public List<Employee> employees = new List<Employee>();

        public bool AddPermanentEmployee(string FirstName, string Surname, decimal Salary, decimal Bonus);

        public bool AddTempEmployee(string FirstName, string LastName, decimal DayRate, int WeeksWorked);

        public List<string> Read();

        public string ReadSingle(int i);

        public bool UpdatePerm(int i, string FirstName, string LastName, decimal Salary, decimal Bonus);
        public bool UpdateTemp(int i, string FirstName, string LastName, decimal DayRate, int WeeksWorked);

        public bool Delete(int i);

        public bool RemoveAll();

    }
}
