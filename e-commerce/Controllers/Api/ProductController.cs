using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace e_commerce.Controllers.Api
{
    public class ProductController : BaseController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Product> Create([FromBody] Product product)
        {
            return await _productService.CreateAsync(product);
        }

        [HttpPut("{id}")]
        public async Task<Product> Update(int id, [FromBody] Product product)
        {
            product.Id = id;
            return await _productService.UpdateAsync(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}