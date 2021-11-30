using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.BL.Interfaces
{
    public interface IOrderItemService
    {
        OrderItem Create(OrderItem orderitem);

        OrderItem Update(OrderItem tag);

        OrderItem Delete(int id);

        OrderItem GetById(int id);

        IEnumerable<OrderItem> GetAll();
    }
}
