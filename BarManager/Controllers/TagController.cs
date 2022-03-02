using System.Threading.Tasks;
using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
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

            var response = _mapper.Map<TagResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody]TagRequest tagRequest)
        {
            if (tagRequest == null) return BadRequest();

            var tag = _mapper.Map<Tag>(tagRequest);

            var result = _tagService.Create(tag);

            return Ok(result);
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
        public async Task<IActionResult> Update([FromBody] TagUpdateRequest tagRequest)
        {
            if (tagRequest == null) return BadRequest();

            var searchTag = await _tagService.GetById(tagRequest.Id);

            if (searchTag == null) return NotFound(tagRequest.Id);

            searchTag.Name = tagRequest.Name;

            var result = _tagService.Update(searchTag);

            return Ok(result);
        }


    }
}
