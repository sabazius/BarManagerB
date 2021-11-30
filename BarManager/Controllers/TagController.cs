using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _tagService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _tagService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody]Tag tag)
        {
            if (tag == null) return BadRequest();

            var result = _tagService.Create(tag);

            return Ok(tag);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);
            
            var result = _tagService.Delete(id);
            
            if (result == null) return NotFound(id);
            
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var searchTag = _tagService.GetById(tag.Id);

            if (searchTag == null) return NotFound(tag.Id);

            var result = _tagService.Update(tag);

            return Ok(result);
        }


    }
}
