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
      
        private readonly CategoryService _categoryService;


        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetById(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        [HttpPost]
        

          public async Task<Category> Create([FromBody] Category category)
         {
          return await _categoryService.CreateAsync(category);
        }

        [HttpPut("{id}")]
        public async Task<Category> Update(int id, [FromBody] Category category)
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
