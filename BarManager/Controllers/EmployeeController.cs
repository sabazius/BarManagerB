using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _employeeService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();

            var result = _employeeService.Create(employee);

            return Ok(employee);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _employeeService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();

            var searchTag = _employeeService.GetById(employee.Id);

            if (searchTag == null) return NotFound(employee.Id);

            var result = _employeeService.Update(employee);

            return Ok(result);
        }
    }
}
