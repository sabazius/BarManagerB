using BarManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.Models.DTO
{
    public class Furnitures
    {
        public int Id { get; set; }
        public FurnituresType Type { get; set; }
        public List<Location> Location { get; set; }
    }
}
