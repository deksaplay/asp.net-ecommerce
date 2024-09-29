using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Services
{
    public class CategoryService : BaseService<Category>
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
           
        }
       


    }
}
