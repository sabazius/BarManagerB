using BarManager.Models.DTO;
using BarManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.Models.Requests
{
    class OrderItemUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public OrderType Type { get; set; }

        public List<Tag> Tags { get; set; }

    }
}
