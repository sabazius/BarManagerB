using BarManager.Models.DTO;
using BarManager.Models.Enums;
using System.Collections.Generic;

namespace BarManager.Models.Requests
{
    public class OrderItemRequest
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public OrderType Type { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
