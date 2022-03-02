using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.BL.Services;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderItemService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = await _orderItemService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<OrderItemResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTag([FromBody] OrderItemRequest orderItemRequest)
        {
            if (orderItemRequest == null) return BadRequest();

            var orderItem = _mapper.Map<OrderItem>(orderItemRequest);

            var result = await _orderItemService.Create(orderItem);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = await _orderItemService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] OrderItem orderItem)
        {
            if (orderItem == null) return BadRequest();

            var searchOrderItem = await _orderItemService.GetById(orderItem.Id);

            if (searchOrderItem == null) return NotFound(orderItem.Id);

            searchOrderItem.Name = orderItem.Name;

            var result = await _orderItemService.Update(searchOrderItem);

            return Ok(result);
        }


    }
}
