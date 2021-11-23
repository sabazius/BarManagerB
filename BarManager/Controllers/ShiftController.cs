using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result = _shiftRepository.GetAll();

            return Ok(result);
            
        }

        [HttpGet("GetByID")]
        public IActionResult GetById(int Id)
        {
            if (Id <= 0) return BadRequest();

            var result = _shiftRepository.GetById(Id);

            if (result == null) return NotFound(Id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateShift([FromBody] Shift shift)
        {
            if (shift == null) return BadRequest();

            var result = _shiftRepository.Create(shift);

            return Ok(shift);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _shiftRepository.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Shift shift)
        {
            if (shift == null) return BadRequest();

            var searchShift = _shiftRepository.GetById(shift.Id);

            if (searchShift == null ) return NotFound();

            var result = _shiftRepository.Update(shift);

            return Ok(result);

        }
    }
}
