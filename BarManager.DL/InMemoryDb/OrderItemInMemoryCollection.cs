using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.DL.InMemoryDb
{
    public static class OrderItemInMemoryCollection
    {
        public static List<OrderItem> OrderItemDb = new List<OrderItem>()
        {
            new OrderItem()
            {
                Id = 1,
                Name = "A",
                Price = 3.50,
                Type = Models.Enums.OrderType.Alcohol,
                Tags = new List<Tag>()
                {
                   new Tag()
                   {
                       Id = 1,
                       Name = "a"
                   } 
                }
            },
           new OrderItem()
            {
                Id = 2,
                Name = "B",
                Price = 2.50,
                Type = Models.Enums.OrderType.Juice,
                Tags = new List<Tag>()
                {
                   new Tag()
                   {
                       Id = 2,
                       Name = "b"
                   }
                }
            },
           new OrderItem()
            {
                Id = 3,
                Name = "C",
                Price = 1.50,
                Type = Models.Enums.OrderType.Water,
                Tags = new List<Tag>()
                {
                   new Tag()
                   {
                       Id = 3,
                       Name = "c"
                   }
                }
            },
          
        };
    }
}