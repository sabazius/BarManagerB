using BarManager.DL.InMemoryDb;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class FurnituresInMemoryRepository : IFurnituresRepository
    {
       public FurnituresInMemoryRepository()
        {

        }
        public Furnitures Create(Furnitures furnitures)
        {
            FurnituresInMemoryCollection.FurnituresDb.Add(furnitures);
                return furnitures;
        }
        public Furnitures Delete(int id)
        {
            var Furnitures = FurnituresInMemoryCollection.FurnituresDb.FirstOrDefault(x => x.Id == id);
            FurnituresInMemoryCollection.FurnituresDb.Remove(Furnitures);
            return Furnitures;
        }
        public IEnumerable<Furnitures> GetAll()
        {
            return FurnituresInMemoryCollection.FurnituresDb;
        }
        public Furnitures GetById(int id)
        {
            return FurnituresInMemoryCollection.FurnituresDb.FirstOrDefault(x => x.Id == id);
        }
        public Furnitures Update(Furnitures furnitures)
        {
            var result = FurnituresInMemoryCollection.FurnituresDb.FirstOrDefault(x => x.Id == furnitures.Id);
            result.Type = furnitures.Type;
            return result;
        }
    }
}
