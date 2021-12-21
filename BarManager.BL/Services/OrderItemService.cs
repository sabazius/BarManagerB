using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public OrderItem Create(OrderItem orderitem)
        {
            var index = _orderItemRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            orderitem.Id = (int)(index != null ? index + 1 : 1);

            return _orderItemRepository.Create(orderitem);
        }

        public OrderItem Delete(int id)
        {
            return _orderItemRepository.Delete(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _orderItemRepository.GetAll();
        }

        public OrderItem GetById(int id)
        {
            return _orderItemRepository.GetById(id);
        }

        public OrderItem Update(OrderItem tag)
        {
            return _orderItemRepository.Update(tag);
        }
    }
}
