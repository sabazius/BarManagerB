using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.InMemoryDb
{
    public static class ProductsInMemoryCollection
    {
        public static List<Products> ProductsDb = new List<Products>()
        {
            new Products()
            {
                Id = 11,
                Name = "NameA",
                Price = 4
            },
            new Products()
            {
                Id = 22,
                Name = "NameB",
                Price = 5
            },
            new Products()
            {
                Id = 33,
                Name = "NameC",
                Price = 6
            }
        };
    }
}
