using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.Base;
namespace e_commerce.Services
{
    public class ShoppingCartService
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ShoppingCartService cart)
        {
            //await _context.ShoppingCartService.AddAsync(cart);
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(ShoppingCartService cart)
        {
            //await _context.ShoppingCarts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

     

      

        
        
    }
}