using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using e_commerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Data;

namespace e_commerce.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly ProductCategoryService _categoryService;

        public ProductCategoryController(ProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dtcategories = _categoryService.GetTableCategory();
            var categories = await _categoryService.GetAllAsync();

            //IEnumerable<ProductCategory> categories = await _categoryService.GetAllAsync();
            //ViewBag.Categories = categories.ToList();

            return View("~/Views/Admin/CategoryProduct/Index.cshtml", dtcategories);
        }
      
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult Create()
        {
            var dtCategory = new DataTable();
            dtCategory.Columns.Add("Name", typeof(string));
            dtCategory.Columns.Add("Description", typeof(string));
            dtCategory.Rows.Add("", ""); // Add an empty row

            return View("~/Views/Admin/CategoryProduct/Create.cshtml", dtCategory);
        }
       
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> Create(IFormCollection form)
        {
            var dtCategory = new DataTable();
            dtCategory.Columns.Add("Name", typeof(string));
            dtCategory.Columns.Add("Description", typeof(string));

            dtCategory.Rows.Add(
                form["Rows[0][Name]"].ToString(),
                form["Rows[0][Description]"].ToString()
            );

            if (ModelState.IsValid)
            {
                // Create a new ProductCategory from the DataTable
                var newCategory = new ProductCategory
                {
                    Name = dtCategory.Rows[0]["Name"].ToString(),
                    Description = dtCategory.Rows[0]["Description"].ToString()
                };

                await _categoryService.CreateAsync(newCategory);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Admin/CategoryProduct/Create.cshtml", dtCategory);
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

            var dtcategories = _categoryService.GetTableCategory(id);
            if (dtcategories.Rows.Count == 0)
            {
                return NotFound();
            }

            //ProductCategory categoryFromDB = await _categoryService.GetByIdAsync(id.Value);
            //if (categoryFromDB == null)
            //{
            //    return NotFound();
            //}

            return View("~/Views/Admin/CategoryProduct/Edit.cshtml", dtcategories);
        }
        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> Edit(int id)
        {


            //if (ModelState.IsValid)
            //{
            //    //await _categoryService.UpdateAsync(category);
            //    return RedirectToAction(nameof(Index));
            //}

            var dtcategories = _categoryService.GetTableCategory(id);
            dtcategories.Rows[0]["Name"] = Request.Form["Rows[0][Name]"].ToString();
            dtcategories.Rows[0]["Description"] = Request.Form["Rows[0][Description]"].ToString();

            _categoryService.UpdateTableCategory(dtcategories);

            return View("~/Views/Admin/CategoryProduct/Edit.cshtml", dtcategories);
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

            var category = await _categoryService.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/CategoryProduct/Delete.cshtml", category);
        }

        [HttpPost]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var dtCategory = _categoryService.GetTableCategory(id);
            if (dtCategory.Rows.Count == 0)
            {
                return NotFound();
            }

            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }







    }
}

