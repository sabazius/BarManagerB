using BarManager.BL.Interfaces;
using BarManager.BL.Services;
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
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService OrderItemService)
        {
            _orderItemService = OrderItemService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderItemService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _orderItemService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody] OrderItem orderItem)
        {
            if (orderItem == null) return BadRequest();

            var result = _orderItemService.Create(orderItem);

            return Ok(orderItem);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _orderItemService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] OrderItem orderItem)
        {
            if (orderItem == null) return BadRequest();

            var searchTag = _orderItemService.GetById(orderItem.Id);

            if (searchTag == null) return NotFound(orderItem.Id);

            var result = _orderItemService.Update(orderItem);

            return Ok(result);
        }


    }
}
