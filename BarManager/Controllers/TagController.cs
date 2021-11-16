using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {

        public TagController()
        {
            
        }

        [HttpGet]
        public Tag Get()
        {
            return new Tag()
            {
                Id = 1,
                Name = "TestTag",
            };
        }


    }
}
