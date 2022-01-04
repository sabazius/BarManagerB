using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public BillController(IBillService billService,IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
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
            var response = _mapper.Map<BillResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateBill([FromBody] BillRequest billRequest)
        {
            if (billRequest == null) return BadRequest();

            var bill = _mapper.Map<Bill>(billRequest);

            var result = _billService.Create(bill);

            return Ok(result);
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
