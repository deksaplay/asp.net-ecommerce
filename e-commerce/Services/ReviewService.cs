using Microsoft.EntityFrameworkCore;
using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Services
{
    public class ReviewService : BaseService<Review>
    {
        public ReviewService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Product)
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }
    }
}