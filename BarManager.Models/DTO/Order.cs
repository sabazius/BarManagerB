using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.Models.DTO
{
    public class Order
    {
        public int ID { get; set; }
        public OrderItem Items { get; set; }

        public Bill Bill { get; set; }
    }
}
