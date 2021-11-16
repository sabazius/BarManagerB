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
    public class ClientController : ControllerBase
    {

        public ClientController()
        {

        }

        [HttpGet]
        public Client Get()
        {
            return new Client()
            {
                Id = 1,
                Name = "TestClient",
                MoneySpend = DateTime.Today,
                Discount = 4
            };
        }


    }
}
