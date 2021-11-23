using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _clientRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _clientRepository.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateClient([FromBody] Client client)
        {
            if (client == null) return BadRequest();

            var result = _clientRepository.Create(client);

            return Ok(client);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _clientRepository.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Client client)
        {
            if (client == null) return BadRequest();

            var searchClient = _clientRepository.GetById(client.Id);

            if (searchClient == null) return NotFound(client.Id);

            var result = _clientRepository.Update(client);

            return Ok(result);
        }


    }
}
