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
        private readonly ShoppingCartService _cartService;

        public ShoppingCartController(ShoppingCartService cartService)
        {
            _cartService = cartService;
        }

      
    }
}