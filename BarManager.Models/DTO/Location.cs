using System;
using System.Collections.Generic;

namespace BarManager.Models.DTO
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static implicit operator Location(List<Location> v)
        {
            throw new NotImplementedException();
        }
    }
}
