using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.Models.Requests
{
    public class ShiftRequest
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
