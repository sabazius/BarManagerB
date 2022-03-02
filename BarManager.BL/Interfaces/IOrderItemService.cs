using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarManager.BL.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItem> Create(OrderItem orderitem);

        Task<OrderItem> Update(OrderItem tag);

        Task<OrderItem> Delete(int id);

        Task<OrderItem> GetById(int id);

        Task<IEnumerable<OrderItem>> GetAll();
    }
}
