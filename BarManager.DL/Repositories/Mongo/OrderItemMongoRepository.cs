using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using BarManager.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<OrderItem> Create(OrderItem orderitem)
        {
            await _orderItemCollection.InsertOneAsync(orderitem);
            
            return orderitem;
        }

        public async Task<OrderItem> Delete(int id)
        {
            var orderIterm = await GetById(id);

            await _orderItemCollection.DeleteOneAsync(orderIterm => orderIterm.Id == id);

            return orderIterm;
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            var result = await _orderItemCollection.FindAsync(orderItem => true);

            return result.ToList();
        }

        public async Task<OrderItem> GetById(int id)
        {
            var result = await _orderItemCollection.FindAsync(orderItem => orderItem.Id == id);

            return result.FirstOrDefault();
        }

        public async Task<OrderItem> Update(OrderItem tag)
        {
           await _orderItemCollection.ReplaceOneAsync(tagToReplace => tagToReplace.Id == tag.Id, tag);
            
            return tag;
        }
    }
}
