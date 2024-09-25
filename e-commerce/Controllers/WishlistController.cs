using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

namespace e_commerce.Controllers
{
    public class WishlistController : BaseController
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWishlistByUserId(int userId)
        {
            var wishlists = await _wishlistService.GetByUserIdAsync(userId);
            return Ok(wishlists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishlistById(int id)
        {
            var wishlist = await _wishlistService.GetByIdAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return Ok(wishlist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWishlist([FromBody] Wishlist wishlist)
        {
            var createdWishlist = await _wishlistService.CreateAsync(wishlist);
            return CreatedAtAction(nameof(GetWishlistById), new { id = createdWishlist.Id }, createdWishlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWishlist(int id, [FromBody] Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }
            var updatedWishlist = await _wishlistService.UpdateAsync(wishlist);
            return Ok(updatedWishlist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            await _wishlistService.DeleteAsync(id);
            return NoContent();
        }
    }
}