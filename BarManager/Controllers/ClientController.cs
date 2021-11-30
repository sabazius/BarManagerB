using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _clientService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateClient([FromBody] Client client)
        {
            if (client == null) return BadRequest();

            var result = _clientService.Create(client);

            return Ok(client);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _clientService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Client client)
        {
            if (client == null) return BadRequest();

            var searchClient = _clientService.GetById(client.Id);

            if (searchClient == null) return NotFound(client.Id);

            var result = _clientService.Update(client);

            return Ok(result);
        }


    }
}
