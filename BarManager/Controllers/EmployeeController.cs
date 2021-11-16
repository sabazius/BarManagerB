using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        public EmployeeController()
        {
            
        }

        [HttpGet]
        public Employee Get()
        {


            return new Employee()
            {
                Id = 1,
                Name = "TestEmployee",
                ClientTable = new List<int>() { 1, 2, 3 },
                Type = Models.Enums.EmployeeType.Waiter
            };
        }


    }
}
