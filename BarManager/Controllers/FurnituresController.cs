using System.Runtime.InteropServices;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BarManager.DL.Interfaces;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FurnituresController : ControllerBase
    {
        private readonly IFurnituresRepository _furnituresRepository;

        public FurnituresController(IFurnituresRepository furnituresRepository)
        {
            _furnituresRepository = furnituresRepository;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _furnituresRepository.GetAll();

            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _furnituresRepository.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody] Furnitures furnitures)
        {
            if (furnitures == null) return BadRequest();

            var result = _furnituresRepository.Create(furnitures);

            return Ok(furnitures);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _furnituresRepository.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] Furnitures furnitures) { 
         
        if (furnitures == null) return BadRequest();

        var searchTag = _furnituresRepository.GetById(furnitures.Id);

            if (searchTag == null) return NotFound(furnitures.Id);

        var result = _furnituresRepository.Update(furnitures);

            return Ok(result);
    }
}
}

