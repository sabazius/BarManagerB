using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _billService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _billService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateBIll([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var result = _billService.Create(bill);

            return Ok(bill);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _billService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var searchBill = _billService.GetById(bill.Id);

            if (searchBill == null) return NotFound(bill.Id);

            var result = _billService.Update(bill);

            return Ok(result);
        }


    }
}
