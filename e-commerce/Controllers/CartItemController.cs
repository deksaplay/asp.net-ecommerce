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

        [HttpGet("{userId}")]
        public async Task<IEnumerable<CartItem>> GetCartItems(int userId)
        {
            return await _cartService.GetCartItemsByUserIdAsync(userId);
        }

        [HttpPost]
        //public async Task<CartItem> AddCartItem([FromBody] CartItem cartItem)
        //{

        //    //return await _cartService.CreateAsync(cartItem);
        //}

        [HttpPut("{id}")]
        //public async Task<CartItem> UpdateCartItem(int id, [FromBody] CartItem cartItem)
        //{
        //    cartItem.Id = id;
        //    //return await _cartService.UpdateAsync(cartItem);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            //await _cartService.DeleteAsync(id);
            return NoContent();
        }
    }
}
