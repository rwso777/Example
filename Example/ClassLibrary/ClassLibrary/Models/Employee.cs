using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    // Investigate: Could be a struct
    public class Employee
    {
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        public decimal? Salary { get; set; }

        public DateTime? HiredDate { get; set; }

        public bool IsValid { get; set; }
    }
}
