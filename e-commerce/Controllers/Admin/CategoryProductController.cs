using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using e_commerce.Data;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class CategoryProductController : Controller
    {
        private readonly CategoryService _categoryService;
        private IEnumerable<Category> categories;

        public CategoryProductController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var cats = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.ToList();
            return View("~/Views/Admin/CategoryProduct/Index.cshtml", cats);
        }
      
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult Create()
        {
            return View("~/Views/Admin/CategoryProduct/Create.cshtml");
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/CategoryProduct/Create.cshtml", category);
        }

        //update category
        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Category categoryFromDB = await _categoryService.GetByIdAsync(id.Value);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/CategoryProduct/Edit.cshtml", categoryFromDB);
        }
        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/CategoryProduct/Edit.cshtml", category);
        }

        //delete category
        [HttpGet]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Category categoryFromDB = await _categoryService.GetByIdAsync(id.Value);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/CategoryProduct/delete.cshtml", categoryFromDB);
        }


        [HttpPost]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeletePOST(int? id)

        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Category? categoryFromDB = await _categoryService.GetByIdAsync(id.Value);
            if (categoryFromDB == null)
            {
                return NotFound(nameof(Category));
            }

            await _categoryService.DeleteAsync(id.Value);
            return RedirectToAction(nameof(Index));

        }








    }
}

