using e_commerce.Data;
using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

//namespace e_commerce.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        private readonly ProductService _productService;
//        public ShoppingCartController(ProductService productService)
//        {
//            _productService = productService;
//        }
//        public IActionResult Details()
//        {
//            // Example data, you would replace this with your database logic
//            List<Product> cartItems = new List<Product>
//            {
//                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 50, ImageFile = null, Stock = 2 },
//                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 100, ImageFile = null, Stock = 1 }
//            };

    //        return View(cartItems);
    //    }
    //    public IActionResult Details_product(int id)
    //    {
    //        var product = _productService.GetProductById(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //    [Authorize]  // Protect this action, only authenticated users can access
    //    public IActionResult Checkout()
    //    {
    //        // Logic for displaying the checkout page
    //        return View();
    //    }
       

    //    }
    //}