using System.Collections.Generic;
using System.Threading.Tasks;
using BarManager.Models.DTO;

namespace BarManager.DL.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> Create(OrderItem orderitem);

        Task<OrderItem> Update(OrderItem tag);

        Task<OrderItem> Delete(int id);

        Task<OrderItem> GetById(int id);

        Task<IEnumerable<OrderItem>> GetAll();
    }
}
