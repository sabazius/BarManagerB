using BarManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.Models.Requests
{
    public class BillRequest
    {
       

        public double Amount { get; set; }

        public BillStatus BillStatus { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }
    }
}
