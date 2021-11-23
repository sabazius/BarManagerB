using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _tagRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _tagRepository.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody]Tag tag)
        {
            if (tag == null) return BadRequest();

            var result = _tagRepository.Create(tag);

            return Ok(tag);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);
            
            var result = _tagRepository.Delete(id);
            
            if (result == null) return NotFound(id);
            
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var searchTag = _tagRepository.GetById(tag.Id);

            if (searchTag == null) return NotFound(tag.Id);

            var result = _tagRepository.Update(tag);

            return Ok(result);
        }


    }
}
