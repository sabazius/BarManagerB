using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.Models.Requests
{
    public class ShiftUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
