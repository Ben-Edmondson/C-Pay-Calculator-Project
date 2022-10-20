namespace PayCalc_Project
{
    public class EmployeeRepository
    {

        public List<Employee> employees = new List<Employee>() {
            new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 },
            new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 },
            new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };

        public bool AddPermanentEmployee(string FirstName, string Surname, decimal Salary, decimal Bonus)
        {
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = FirstName, LastName = Surname, Salary = Salary, Bonus = Bonus });
            return true;
        }

        public bool AddTempEmployee( string FirstName, string LastName, decimal DayRate, int WeeksWorked)
        {
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Temporary, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked= WeeksWorked });
            return true;
        }

        public List<string> Read()
        {
            List<string> ReadAll = new List<string>();
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmploymentType == TypeOfEmployment.Permanent)
                {
                    ReadAll.Add($"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Salary: {employees[i].Salary} Bonus {employees[i].Bonus}");
                }
                else
                {
                    ReadAll.Add($"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Day Rate: {employees[i].DayRate} Weeks Worked: {employees[i].WeeksWorked}");
                }
            }
            return ReadAll;
        }

        public string ReadSingle(int i)
        {
            if (employees.Count() > i)
            {
                if (employees[i].EmploymentType == TypeOfEmployment.Permanent)
                {
                    string ReadSingleEmployee = $"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Salary: {employees[i].Salary} Bonus {employees[i].Bonus} ";
                    return ReadSingleEmployee;
                }
                else
                {
                    string ReadSingleEmployee = $"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Day Rate: {employees[i].DayRate} Weeks Worked: {employees[i].WeeksWorked}";
                    return ReadSingleEmployee;
                }
            }
            string Failed = "Failed to read, ID is too high.";
            return Failed;
        }

        public bool UpdatePerm(int i,string FirstName, string LastName,decimal Salary, decimal Bonus)
        {
            employees[i].FirstName = FirstName;
            employees[i].LastName = LastName;
            employees[i].Salary = Salary;
            employees[i].Bonus = Bonus;
            return true;
        }
        public bool UpdateTemp(int i, string FirstName, string LastName, decimal DayRate, int WeeksWorked)
        {
            employees[i].FirstName = FirstName;
            employees[i].LastName = LastName;
            employees[i].DayRate = DayRate;
            employees[i].WeeksWorked = WeeksWorked;
            return true;
        }

        public bool Delete(int i)
        {
            int EmployeeCount = employees.Count();
            employees.RemoveAt(i);
            if (employees.Count() >= EmployeeCount)
            {
                return false;
            }
            return true;
        }

        public bool RemoveAll()
        {
            employees.Clear();
            if(employees.Count() > 0)
            {
                return false;
            }
            return true;
        }

    }
}
