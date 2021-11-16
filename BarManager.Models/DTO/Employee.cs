using BarManager.Models.Enums;
using System.Collections.Generic;

namespace BarManager.Models.DTO
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EmployeeType Type { get; set; }


        public List<int> ClientTable { get; set;  }

    }
}
