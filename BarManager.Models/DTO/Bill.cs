using BarManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.Models.DTO
{
    public class Bill
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public BillStatus BillStatus { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished{ get; set; }
 
    }
}
