using BarManager.Models.DTO;
using BarManager.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {

        public BillController()
        {

        }

        [HttpGet]
        public Bill Get()
        {
            return new Bill()
            {
                Id = 1,
                Amount = 10.50,
                billStatus = 0,
                paymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)





            };
        }


    }
}
