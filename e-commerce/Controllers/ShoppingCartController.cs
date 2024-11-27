using e_commerce.Data;
using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace e_commerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ProductService _productService;
        public ShoppingCartController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details()
        {
            // Example data, you would replace this with your database logic
            List<Product> cartItems = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 50, ImageFile = null, Stock = 2 },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 100, ImageFile = null, Stock = 1 }
            };

            return View(cartItems);
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> DetailsProductAsync(int? id)
        {
            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/ShoppingCart/DetailsProduct.cshtml", product);
        }

        [Authorize]  // Protect this action, only authenticated users can access
        public IActionResult Checkout()
        {
            // Logic for displaying the checkout page
            return View();
        }


    }
}