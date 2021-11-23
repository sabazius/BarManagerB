using System.Collections.Generic;

namespace BarManager.Models.DTO
{
    public class Shift
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
