using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _billRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _billRepository.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateBIll([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var result = _billRepository.Create(bill);

            return Ok(bill);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _billRepository.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var searchBill = _billRepository.GetById(bill.Id);

            if (searchBill == null) return NotFound(bill.Id);

            var result = _billRepository.Update(bill);

            return Ok(result);
        }


    }
}
