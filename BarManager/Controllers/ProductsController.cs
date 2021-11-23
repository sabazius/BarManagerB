using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productsRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _productsRepository.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateTag([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var result = _productsRepository.Create(products);

            return Ok(products);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _productsRepository.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var searchProducts = _productsRepository.GetById(products.Id);

            if (searchProducts == null) return NotFound(products.Id);

            var result = _productsRepository.Update(products);

            return Ok(result);
        }


    }
}

