using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.BL.Services
{
    public class OrderItemService : IOrderItemService
    {

        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public OrderItem Create(OrderItem orderitem)
        {
           
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
