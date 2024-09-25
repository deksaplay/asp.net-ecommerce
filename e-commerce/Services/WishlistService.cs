using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_commerce.Base;
namespace e_commerce.Services
{
    public class WishlistService : BaseService<Wishlist>
    {
        public WishlistService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Wishlist>> GetByUserIdAsync(int userId)
        {
            return await _context.Wishlists.Where(w => w.UserId == userId).ToListAsync();
        }
    }
}