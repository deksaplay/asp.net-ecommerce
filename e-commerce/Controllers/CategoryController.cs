using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace e_commerce.Controllers
{
    public class CategoryController : BaseController
    {
      
        private readonly ProductCategoryService _categoryService;


        public CategoryController(ProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _categoryService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductCategory> GetById(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        [HttpPost]
        

          public async Task<ProductCategory> Create([FromBody] ProductCategory category)
         {
          return await _categoryService.CreateAsync(category);
        }

        [HttpPut("{id}")]
        public async Task<ProductCategory> Update(int id, [FromBody] ProductCategory category)
        {
            category.Id = id;
            return await _categoryService.UpdateAsync(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
