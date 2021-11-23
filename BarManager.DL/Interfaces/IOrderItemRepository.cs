using System.Collections.Generic;
using BarManager.Models.DTO;

namespace BarManager.DL.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem Create(OrderItem orderitem);

        OrderItem Update(OrderItem tag);

        OrderItem Delete(int id);

        OrderItem GetById(int id);

        IEnumerable<OrderItem> GetAll();
    }
}
