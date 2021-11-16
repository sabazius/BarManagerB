using System.Runtime.InteropServices;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FurnituresController : ControllerBase
    {

        public FurnituresController()
        {

        }

        [HttpGet]
        public Furnitures Get()
        {
            var location = new List<Location>();
            location.Add(new Location() { Id = 3, Name = "Warehouse" });

            return new Furnitures()
            {
                Id = 1,
                Type = Models.Enums.FurnituresType.Chair,
                Location = location
            };
        }


    }
}
