using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.InMemoryDb
{
    public static class ClientInMemoryCollection
    {
        public static List<Client> ClientDb = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Name = "NameA",
                Discount = 1,
                MoneySpend = DateTime.Now
            },
            new Client()
            {
                Id = 2,
                Name = "NameB",
                Discount = 2,
                MoneySpend = DateTime.Now
            },
            new Client()
            {
                Id = 3,
                Name = "NameC",
                Discount = 3,
                MoneySpend = DateTime.Now
            }
        };
    }
}