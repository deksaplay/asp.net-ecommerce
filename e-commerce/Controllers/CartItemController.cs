using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
namespace e_commerce.Controllers
{
    public class CartItemController : BaseController
    {
        private readonly ShoppingCartService _cartService;

        public CartItemController(ShoppingCartService cartService)
        {
            _cartService = cartService;
        }

      
    }
}
