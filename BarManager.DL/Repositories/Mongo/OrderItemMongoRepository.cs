using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using BarManager.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BarManager.DL.Repositories.Mongo
{
    public class OrderItemMongoRepository : IOrderItemRepository
    {
        private readonly IMongoCollection<OrderItem> _orderItemCollection;

        public OrderItemMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _orderItemCollection = database.GetCollection<OrderItem>("OrderItems");

        }

        public OrderItem Create(OrderItem orderitem)
        {
            _orderItemCollection.InsertOne(orderitem);
            
            return orderitem;
        }

        public OrderItem Delete(int id)
        {
            var orderIterm = GetById(id);

            _orderItemCollection.DeleteOne(orderIterm => orderIterm.Id == id);

            return orderIterm;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _orderItemCollection.Find(orderItem => true).ToList();
        }

        public OrderItem GetById(int id)
        {
            return _orderItemCollection.Find(orderItem => orderItem.Id == id).FirstOrDefault();
        }

        public OrderItem Update(OrderItem tag)
        {
            _orderItemCollection.ReplaceOne(tagToReplace => tagToReplace.Id == tag.Id, tag);
            
            return tag;
        }
    }
}
