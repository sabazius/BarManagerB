using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using BarManager.Models.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarManager.DL.Repositories.Mongo
{
    public class ShiftMongoRepository : IShiftRepository

    {
        private readonly IMongoCollection<Shift> _shiftCollection;
        
        public ShiftMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _shiftCollection = database.GetCollection<Shift>("Shifts");
        }

        public Shift Create(Shift shift)
        {
            _shiftCollection.InsertOne(shift);

            return shift;
        }

        public Shift Delete(int id)
        {
            var shift = GetById(id);
            _shiftCollection.DeleteOne(shift => shift.Id == id);

            return shift;
        }

        public IEnumerable<Shift> GetAll()
        {
            return _shiftCollection.Find(shift => true).ToList();
        }

        public Shift GetById(int id)
        {
            return _shiftCollection.Find(shift => shift.Id == id).FirstOrDefault();
        }

        public Shift Update(Shift shift)
        {
            _shiftCollection.ReplaceOne(shiftToReplace => shiftToReplace.Id == shift.Id, shift);
            return shift;
        }
    }
}
