using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace e_commerce.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ProductCategoryService _categoryService;

        public ProductController(ProductService productService, ProductCategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
       
        public async Task<IActionResult> Index()
        {
           var products = await _productService.GetAllAsync();
            return View("~/Views/Admin/Product/Index.cshtml", products);
        }

        
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the product from the database using the service
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product); // Pass the product to the view

        }

        [HttpGet]
        [Route("ShowImage/{id}")]
        public async Task<ActionResult> ShowImage(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product?.ImageFile == null)
            {
                return NotFound(); // Ensure the image exists
            }

            return File(product.ImageFile, "image/jpg");
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> Create()
        {
            // Populate categories for the dropdown
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View("~/Views/Admin/Product/Create.cshtml");
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> Create(Product product, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (files != null && files.Count > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await files[0].CopyToAsync(ms);
                        product.ImageFile = ms.ToArray();
                        product.ImagePath = files[0].FileName;
                    }
                }

                await _productService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            // Repopulate categories for the dropdown if model state is invalid
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", product.ProductCategoryId);
            return View("~/Views/Admin/Product/Create.cshtml", product);
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            // Populate categories for the dropdown
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", product.ProductCategoryId);
            return View("~/Views/Admin/Product/Edit.cshtml", product);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> Edit(Product product, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (files != null && files.Count > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await files[0].CopyToAsync(ms);
                        product.ImageFile = ms.ToArray();
                        product.ImagePath = files[0].FileName;
                    }
                }

                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            // Repopulate categories for the dropdown if model state is invalid
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", product.ProductCategoryId);
            return View("~/Views/Admin/Product/Edit.cshtml", product);
        }

        [HttpGet]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Product/Delete.cshtml", product);
        }

        [HttpPost]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
