using BarManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.Models.Requests
{
   public class EmployeeUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeType Type { get; set; }
        public List<int> ClientTable { get; set; }
    }
}
