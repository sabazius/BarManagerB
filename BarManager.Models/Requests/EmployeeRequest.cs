using BarManager.Models.Enums;
using System.Collections.Generic;

namespace BarManager.Models.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public EmployeeType Type { get; set; }
        public List<int> ClientTable { get; set; }
    }
}
