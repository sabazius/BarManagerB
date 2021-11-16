using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        public ProductsController()
        {

        }

        [HttpGet]
        public Products Get()
        {
            return new Products()
            {
                Id = 1,
                Name = "TestProducts",
                Price = 2
            };
        }


    }
}
