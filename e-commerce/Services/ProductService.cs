using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
            var products = from p in context.Products
                           join c in context.ProductCategories on p.ProductCategoryId equals c.Id
                           select new
                           {
                               ProductName = p.Name, // Give a unique name
                               CategoryName = c.Name  // Give a unique name
                           };
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductCategory) // Ensure related data is included
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
