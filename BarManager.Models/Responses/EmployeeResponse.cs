using BarManager.Models.Enums;
using System.Collections.Generic;

namespace BarManager.Models.Responses
{
   public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeType Type { get; set; }
        public List<int> ClientTable { get; set; }
    }
}
