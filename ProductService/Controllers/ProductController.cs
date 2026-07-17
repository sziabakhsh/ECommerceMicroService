using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs.Product;
using ProductService.Interfaces;
using ProductService.Mappers;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllProductsAsync();
            return Ok(products.Select(p => p.ToProductDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDto productRequest)
        {
            var product = productRequest.ToProduct();
            await _productRepo.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product.ToProductDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductRequestDto productRequest)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            product = productRequest.ToProduct();

            await _productRepo.UpdateProductAsync(product);
            return Ok(product.ToProductDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepo.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
