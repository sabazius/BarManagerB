using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemController(IOrderItemRepository OrderItemRepository)
        {
            _orderItemRepository = OrderItemRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderItemRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _orderItemRepository.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody] OrderItem orderItem)
        {
            if (orderItem == null) return BadRequest();

            var result = _orderItemRepository.Create(orderItem);

            return Ok(orderItem);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _orderItemRepository.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] OrderItem orderItem)
        {
            if (orderItem == null) return BadRequest();

            var searchTag = _orderItemRepository.GetById(orderItem.Id);

            if (searchTag == null) return NotFound(orderItem.Id);

            var result = _orderItemRepository.Update(orderItem);

            return Ok(result);
        }


    }
}
