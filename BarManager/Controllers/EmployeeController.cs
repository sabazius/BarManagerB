using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;
namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
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

            var response = _mapper.Map<EmployeeResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null) return BadRequest();

            var employee = _mapper.Map<Employee>(employeeRequest);

            var result = _employeeService.Create(employee);

            return Ok(result);
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
