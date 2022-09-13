namespace PayCalc_Project
{
    class CRUD
    {
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
            employees[i] = new Employee()
            {
                ID = Guid.NewGuid(),
                EmploymentType = TypeOfEmployment.Permanent,
                FirstName = Input.FirstNameInput(),
                LastName = Input.LastNameInput(),
                DayRate = Input.DayRate(),
                WeeksWorked = Input.WeeksWorked()
            };
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
