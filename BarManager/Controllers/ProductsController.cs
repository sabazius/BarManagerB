using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productsService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _productsService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<ProductsResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateProducts([FromBody] ProductsRequest productsRequest)
        {
            if (productsRequest == null) return BadRequest();

            var products = _mapper.Map<Products>(productsRequest);

            var result = _productsService.Create(products);

            return Ok(products);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _productsService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var searchProducts = _productsService.GetById(products.Id);

            if (searchProducts == null) return NotFound(products.Id);

            var result = _productsService.Update(products);

            return Ok(result);
        }


    }
}
