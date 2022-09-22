using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_Project.Models
{
    class EmployeeTemp : Employee
    {
        public decimal DayRate { get; set; }
        public int WeeksWorked { get; set; }
    }
}
