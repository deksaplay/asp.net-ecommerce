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
        public async Task<IActionResult> Create(Product product, List<IFormFile> ImageFile)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                //}

                if (ImageFile != null && ImageFile.Count > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await ImageFile[0].CopyToAsync(ms);
                        product.ImageFile = ms.ToArray();
                        product.ImagePath = ImageFile[0].FileName;

                        throw new Exception("fdfdsfds");
                    }
                }

                await _productService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Fetch the list of products to pass to the view
                var products = await _productService.GetAllAsync();
                ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", product.ProductCategoryId);
                ViewData["ErrMsg"] = ex.Message;
                return View("~/Views/Admin/Product/Create.cshtml", products);
            }
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
        public async Task<IActionResult> Edit(Product product, List<IFormFile> file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Count > 0)
                {
                    Stream input = file[0].OpenReadStream();
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                        product.ImagePath = file[0].FileName;
                        product.ImageFile = ms.ToArray();
                    }
                }

                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            // Fetch the list of products to pass to the view
            var products = await _productService.GetAllAsync();
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", product.ProductCategoryId);
            return View("~/Views/Admin/Product/Edit.cshtml", products);
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