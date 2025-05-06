using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;
using StoreApi.Services;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> PostProduct([FromBody] ProductRequest productRequest)
        {
            if (productRequest == null) return BadRequest("Invalid product data.");

            var product = new Product
            {
                Name = productRequest.Name,
                ShortDescription = productRequest.ShortDescription,
                LongDescription = productRequest.LongDescription,
                Price = productRequest.Price,
                InStock = productRequest.InStock,
                CategoryId = productRequest.CategoryId
            };

            _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] ProductRequest productRequest)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = productRequest.Name;
            existingProduct.ShortDescription = productRequest.ShortDescription;
            existingProduct.LongDescription = productRequest.LongDescription;
            existingProduct.Price = productRequest.Price;
            existingProduct.InStock = productRequest.InStock;
            existingProduct.CategoryId = productRequest.CategoryId;

            _productService.UpdateProduct(existingProduct);
            return NoContent();
        }
    }
}
