using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        public ShiftController()
        {
                
        }

        [HttpGet]
        public Shift Get() 
        {
            var employees = new List<int>();
            return new Shift
            {
                Id = 1,
                Name = "Ivan",
                Employees = new List<int>() { 1, 2, 3 }

            };
        }

    }
}
