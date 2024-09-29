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
        private readonly CategoryService _categoryService;
        public ProductController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var cats = await _productService.GetAllAsync();
           

            return View("~/Views/Admin/Product/Index.cshtml", cats);
        }

        [HttpGet]
        [Route("ShowImage/{id}")]
        public async Task<ActionResult> ShowImage(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Product ProductFromDB = await _productService.GetByIdAsync(id.Value);


            return File(ProductFromDB.ImageFile, "image/jpg");
        }


        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
          
            // Mengirimkan model kosong ke view untuk mencegah NullReferenceException

            return View("~/Views/Admin/Product/Create.cshtml");
            
        }
       

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> Create(Product product)


        {
            if (ModelState.IsValid)
            {
                await _productService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            // Jika ada error dalam validasi, tampilkan ulang kategori
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
           
            return View("~/Views/Admin/Product/Create.cshtml", product);
        }

        //update Product
        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Product ProductFromDB = await _productService.GetByIdAsync(id.Value);
            if (ProductFromDB == null)
            {
                return NotFound();
            }
            // Ambil semua kategori dan simpan dalam ViewBag atau ViewData
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View("~/Views/Admin/Product/Edit.cshtml", ProductFromDB);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> Edit(Product product, List<IFormFile> file)
        {

            if (ModelState.IsValid)
            {
                if(file != null && file.Count > 0) {
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

            // Ambil semua kategori dan simpan dalam ViewBag atau ViewData
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View("~/Views/Admin/Product/Edit.cshtml", product);
        }
       

        //delete Product
        [HttpGet]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Product productFromDB = await _productService.GetByIdAsync(id.Value);
            if (productFromDB == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Product/delete.cshtml", productFromDB);
        }


        [HttpPost]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeletePOST(int? id)

        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Product? productFromDB = null;
            try
            {
                productFromDB = await _productService.GetByIdAsync(id.Value);
                if (productFromDB == null)
                {
                    return NotFound(nameof(Product));
                }

                await _productService.DeleteAsync(id.Value);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMsg"] = ex.Message;
                return View("~/Views/Admin/Product/delete.cshtml", productFromDB);
            }
        }
    }
}
