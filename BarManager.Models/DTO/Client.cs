using System;
using System.Collections.Generic;
using System.Text;


namespace BarManager.Models.DTO
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime MoneySpend { get; set; }

        public int Discount { get; set; }

    }
}
