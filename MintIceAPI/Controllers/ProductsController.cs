using Microsoft.AspNetCore.Mvc;
using MintIceAPI.Models;
using MintIceAPI.Services;

namespace MintIceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly ProductService _productService;
        public ProductsController(ProductService productService, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("get-all-by-created-at/{date}")]
        public IActionResult GetAllByCreatedAt(DateTime date)
        {
            return Ok(_productService.GetAllByCreatedAt(date));
        }

        [HttpGet("get-all-by-filtering/{dateFrom}/{dateTo}")]
        public IActionResult GetAllByFiltering(DateTime dateFrom, DateTime dateTo)
        {
            return Ok(_productService.GetAllByFiltering(dateFrom, dateTo));
        }

        [HttpPost]
        public IActionResult Create(ProductCreateRequest model)
        {
            _productService.Create(model);
            return Ok(new { message = "Product created" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateRequest model)
        {
            _productService.Update(id, model);
            return Ok(new { message = "Product updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok(new { message = "Product deleted" });
        }
    }
}
