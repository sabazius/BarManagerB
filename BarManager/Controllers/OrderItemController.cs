using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.BL.Services;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService OrderItemService, IMapper mapper)
        {
            _orderItemService = OrderItemService;
            _mapper = mapper;
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

            var response = _mapper.Map<OrderItemResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody] OrderItemRequest orderItemRequest)
        {
            if (orderItemRequest == null) return BadRequest();

            var orderItem = _mapper.Map<OrderItem>(orderItemRequest);

            var result = _orderItemService.Create(orderItem);

            return Ok(result);
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
