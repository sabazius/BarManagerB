using System.Runtime.InteropServices;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BarManager.DL.Interfaces;
using BarManager.BL.Interfaces;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FurnituresController : ControllerBase
    {
        private readonly IFurnituresService _furnituresService;

        public FurnituresController(IFurnituresService FurnituresService)
        {
            _furnituresService = FurnituresService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _furnituresService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _furnituresService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody] Furnitures furnitures)
        {
            if (furnitures == null) return BadRequest();

            var result = _furnituresService.Create(furnitures);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _furnituresService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] Furnitures furnitures)
        { 
        if (furnitures == null) return BadRequest();

        var searchTag = _furnituresService.GetById(furnitures.Id);

            if (searchTag == null) return NotFound(furnitures.Id);

        var result = _furnituresService.Update(furnitures);

            return Ok(result);
        }
    }
}

