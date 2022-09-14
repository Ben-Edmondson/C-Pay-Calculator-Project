﻿namespace PayCalc_Project
{
    class CRUD
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
            employees.Add(new Employee() { ID = Guid.NewGuid(), EmploymentType = TypeOfEmployment.Permanent, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked= WeeksWorked });
            return true;
        }

        public List<string> Read()
        {
            List<string> ReadAll = new List<string>();
            for (int i = 0; i < employees.Count; i++)
            {
                ReadAll.Add($"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Annual Pay: {Calculations.TotalAnnualPay(employees, i)}");
            }
            return ReadAll;
        }

        public string ReadSingle(int i)
        {
            if (employees.Count() > i)
            {
                string ReadSingleEmployee = $"{employees[i].FullName} Status: {employees[i].EmploymentType.ToString()} Annual Pay: {Calculations.TotalAnnualPay(employees, i)} ";
                return ReadSingleEmployee;
            }
            string Failed = "Failed to read, ID is too high.";
            return Failed;
        }

        public bool Update(int i)
        {
            employees[i].FirstName = null;
            employees[i].LastName = null;
            if (employees[i].EmploymentType == TypeOfEmployment.Permanent)
            {
                employees[i].Salary = 0;
                employees[i].Bonus = 0;
            }
            else
            {
                employees[i].DayRate = 0;
                employees[i].WeeksWorked = 0;
            }
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
