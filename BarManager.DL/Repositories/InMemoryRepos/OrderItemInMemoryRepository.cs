using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManager.DL.InMemoryDb;
using System.Threading.Tasks;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class OrderItemInMemoryRepository : IOrderItemRepository
    {

        public OrderItemInMemoryRepository()
        {

        }

        public Task<OrderItem> Create(OrderItem orderItem)
        {
            OrderItemInMemoryCollection.OrderItemDb.Add(orderItem);

            return Task.FromResult(orderItem);
        }

        public Task<OrderItem> Delete(int id)
        {
            var orderItem = OrderItemInMemoryCollection.OrderItemDb.FirstOrDefault(tag => tag.Id == id);

            OrderItemInMemoryCollection.OrderItemDb.Remove(orderItem);

            return Task.FromResult(orderItem);
        }

        public Task<IEnumerable<OrderItem>> GetAll()
        {
            return Task.FromResult(OrderItemInMemoryCollection.OrderItemDb.AsEnumerable());
        }

        public Task<OrderItem> GetById(int id)
        {
            return Task.FromResult(OrderItemInMemoryCollection.OrderItemDb.FirstOrDefault(x => x.Id == id));
        }

        public Task<OrderItem> Update(OrderItem orderItem)
        {
            var result = OrderItemInMemoryCollection.OrderItemDb.FirstOrDefault(x => x.Id == orderItem.Id);

            result.Name = orderItem.Name;

            return Task.FromResult(orderItem);
        }
    }
}