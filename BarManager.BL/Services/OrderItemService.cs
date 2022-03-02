using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManager.BL.Services
{
    public class OrderItemService : IOrderItemService
    {

        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ILogger _logger;

        public OrderItemService(IOrderItemRepository orderItemRepository, ILogger logger)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Create(OrderItem orderitem)
        {
            var result = await _orderItemRepository.GetAll();

            var index = result.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            orderitem.Id = (int)(index != null ? index + 1 : 1);

            return await _orderItemRepository.Create(orderitem);
        }

        public async Task<OrderItem> Delete(int id)
        {
            return await _orderItemRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _orderItemRepository.GetAll();
        }

        public async Task<OrderItem> GetById(int id)
        {
            return await _orderItemRepository.GetById(id);
        }

        public async Task<OrderItem> Update(OrderItem tag)
        {
            return await _orderItemRepository.Update(tag);
        }
    }
}
