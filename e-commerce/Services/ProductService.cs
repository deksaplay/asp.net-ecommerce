using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;
namespace e_commerce.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(ApplicationDbContext context) : base(context)
        {
        }
    }
}