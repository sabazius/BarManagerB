using BarManager.Models.DTO;
using BarManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.InMemoryDb
{
    class FurnituresInMemoryCollection
    {
        public static List<Furnitures> FurnituresDb = new List<Furnitures>()
        {
            new Furnitures()
            {
                Id = 1,
                Type = FurnituresType.Chair,
                Location = new List<Location>()
                {
                    new Location()
                    {
                        Id = 1,
                        Name = "Warehouse"
                    }
                }
            },
            new Furnitures()
            {
                Id = 2,
                Type = FurnituresType.Table,
                Location = new List<Location>()
                {
                    new Location()
                    {
                        Id = 2,
                        Name = "Bar"
                    }
                }
            },
            new Furnitures()
            {
                Id = 3,
                Type = FurnituresType.Umbrella,
                Location = new List<Location>()
                {
                    new Location()
                    {
                        Id = 3,
                        Name = "Entrance"
                    }
                }
            },
        };
    }
}