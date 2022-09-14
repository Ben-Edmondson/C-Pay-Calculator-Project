namespace PayCalc_Project
{
    class CRUD
    {

        public static List<Employee> EmployeesInit() {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "Joe", LastName = "Bloggs", Salary = 40000, Bonus = 5000 });
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = "John", LastName = "Smith", Salary = 45000, Bonus = 2500 });
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Temporary, FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 });
            return employees;
        }

        public static List<Employee> AddPermanentEmployee(List<Employee>employees, string FirstName, string Surname, decimal Salary, decimal Bonus)
        {
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = FirstName, LastName = Surname, Salary = Salary, Bonus = Bonus });
            return employees;
        }

        public static List<Employee> AddTempEmployee(List<Employee>employees, string FirstName, string LastName, decimal DayRate, int WeeksWorked)
        {
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked= WeeksWorked });
            return employees;
        }

        public static void Read(List<Employee>employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Annual Pay: {Calculations.TotalAnnualPay(employees, i)} Hourly Pay: {Calculations.doubleHourlyRate(employees, i)} ");
            }
            Console.ReadLine();
        }

        public static void ReadSingle(List<Employee>employees, int i)
        {
            Console.WriteLine($"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Annual Pay: {Calculations.TotalAnnualPay(employees, i)} Hourly Pay: {Calculations.doubleHourlyRate(employees, i)} ");
            Console.ReadLine();
        }

        public List<Employee> Update(List<Employee> employees, int i)
        {
            string strEmployType = Program.TypeOfEmploymentString();
            if (strEmployType.ToLower() == "permanent")
            {
                employees[i] = new Employee()
                {
                    ID = Guid.NewGuid(),
                    EmploymentType = TypeOfEmployment.Permanent,
                    FirstName = Program.FirstNameInput(),
                    LastName = Program.LastNameInput(),
                    Salary = Program.SalaryInput(),
                    Bonus = Program.BonusInput()
                };
            }
            else
            {
                employees[i] = new Employee()
                {
                    ID = Guid.NewGuid(),
                    EmploymentType = TypeOfEmployment.Temporary,
                    FirstName = Program.FirstNameInput(),
                    LastName = Program.LastNameInput(),
                    DayRate = Program.DayRateInput(),
                    WeeksWorked = Program.WeeksWorkedInput()
                };
            }
            return employees;
        }

        public List<Employee> Delete(List<Employee> employees,int i)
        {
            employees.RemoveAt(i);
            return employees;
        }

        public List<Employee> RemoveAll(List<Employee>employees)
        {
            employees.Clear();
            return employees;
        }

    }
}
