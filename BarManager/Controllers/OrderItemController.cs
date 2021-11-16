using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {

        public OrderItemController()
        {

        }

        [HttpGet]
        public OrderItem Get()
        {
            var tags = new List<Tag>();
            tags.Add(new Tag()
            {
                Id = 1,
                Name = "Test"
            });
            return new OrderItem()
            {
                Id = 1,
                Name = "TestOrder",
                Price = 2.50,
                Type = Models.Enums.OrderType.Juice,
                Tags = tags,
            };
        }


    }
}
