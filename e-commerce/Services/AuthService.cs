using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace e_commerce.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

       
    }
}