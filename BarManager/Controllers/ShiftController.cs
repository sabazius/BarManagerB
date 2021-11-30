using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result = _shiftService.GetAll();

            return Ok(result);
            
        }

        [HttpGet("GetByID")]
        public IActionResult GetById(int Id)
        {
            if (Id <= 0) return BadRequest();

            var result = _shiftService.GetById(Id);

            if (result == null) return NotFound(Id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateShift([FromBody] Shift shift)
        {
            if (shift == null) return BadRequest();

            var result = _shiftService.Create(shift);

            return Ok(shift);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _shiftService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Shift shift)
        {
            if (shift == null) return BadRequest();

            var searchShift = _shiftService.GetById(shift.Id);

            if (searchShift == null ) return NotFound();

            var result = _shiftService.Update(shift);

            return Ok(result);

        }
    }
}
