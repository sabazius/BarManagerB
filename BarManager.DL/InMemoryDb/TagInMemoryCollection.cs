using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.DL.InMemoryDb
{
    public static class TagInMemoryCollection
    {
        public static List<Tag> TagDb = new List<Tag>()
        {
            new Tag()
            {
                Id = 1,
                Name = "NameA"
            },
            new Tag()
            {
                Id = 2,
                Name = "NameB"
            },
            new Tag()
            {
                Id = 3,
                Name = "NameC"
            }
        };
    }
}
