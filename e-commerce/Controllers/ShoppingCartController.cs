using e_commerce.Data;
using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace e_commerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        public class ShoppingCartController : Controller
        {
            public IActionResult Details()
            {
                // Example data, you would replace this with your database logic
                List<Product> cartItems = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 50, ImageFile = null, Quantity = 2 },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 100, ImageFile = null, Quantity = 1 }
            };

                return View(cartItems);
            }
        }
    }