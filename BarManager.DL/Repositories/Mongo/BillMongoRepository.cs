using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Bill = BarManager.Models.DTO.Bill;

namespace BarManager.DL.Repositories.Mongo
{
    public class BillMongoRepository : IBillRepository
    {
        private readonly IMongoCollection<Bill> _billCollection;

        public BillMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _billCollection = database.GetCollection<Bill>("Bills");
        }

        public Bill Create(Bill bill)
        {
            _billCollection.InsertOne(bill);

            return bill;
        }

        public Bill Update(Bill bill)
        {
            _billCollection.ReplaceOne(billToReplace => billToReplace.Id == bill.Id, bill);
            return bill;
        }

        public Bill Delete(int id)
        {
            var bill = GetById(id);
            _billCollection.DeleteOne(Bill => Bill.Id == id);

            return bill;
        }

        public Bill GetById(int id)
        {
            return _billCollection.Find(Bill => Bill.Id == id).FirstOrDefault();
        }

        public IEnumerable<Bill> GetAll()
        {
            return _billCollection.Find(bill => true).ToList();
        }
    }
}
