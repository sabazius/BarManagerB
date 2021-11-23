using BarManager.Models.DTO;
using System;
using System.Collections.Generic;

namespace BarManager.DL.InMemoryDb
{
    public static class BillInMemoryCollection
    {
        public static List<Bill> BillDb = new List<Bill>()
        {
            new Bill()
            {
                Id = 1,
                Amount = 10.50,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            },
            new Bill()
            {
                   Id = 2,
                Amount = 20.50,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            },
            new Bill()
            {
                        Id = 3,
                Amount = 60,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            }
        };
    }
}