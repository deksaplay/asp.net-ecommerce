using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;
namespace e_commerce.Services
{
    public class CheckoutService : BaseService<Order>
    {
        public CheckoutService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
        }

       
        
    }
}