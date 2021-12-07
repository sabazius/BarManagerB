using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.Models.Responses
{
    public class ShiftResponse
    {
        public string Name { get; set; }

        public int Id { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
