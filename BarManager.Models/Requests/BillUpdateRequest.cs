using BarManager.Models.Enums;
using System;

namespace BarManager.Models.Requests
{
    public class BillUpdateRequest
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public BillStatus BillStatus { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }

    }
}
