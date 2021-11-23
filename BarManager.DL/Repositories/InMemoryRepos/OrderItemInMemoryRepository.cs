using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManager.DL.InMemoryDb;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class OrderItemInMemoryRepository : IOrderItemRepository
    {

        public OrderItemInMemoryRepository()
        {

        }

        public OrderItem Create(OrderItem orderItem)
        {
            OrderItemInMemoryCollection.OrderItemDb.Add(orderItem);

            return orderItem;
        }

        public OrderItem Delete(int id)
        {
            var orderItem = OrderItemInMemoryCollection.OrderItemDb.FirstOrDefault(tag => tag.Id == id);

            OrderItemInMemoryCollection.OrderItemDb.Remove(orderItem);

            return orderItem;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return OrderItemInMemoryCollection.OrderItemDb;
        }

        public OrderItem GetById(int id)
        {
            return OrderItemInMemoryCollection.OrderItemDb.FirstOrDefault(x => x.Id == id);
        }

        public OrderItem Update(OrderItem orderItem)
        {
            var result = OrderItemInMemoryCollection.OrderItemDb.FirstOrDefault(x => x.Id == orderItem.Id);

            result.Name = orderItem.Name;

            return result;
        }
    }
}