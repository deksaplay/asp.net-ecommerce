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
        public CheckoutService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Order> CheckoutAsync(int userId)
        {
            var cartItems = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();

            if (cartItems == null || !cartItems.Any())
            {
                return null;
            }

            List<OrderItem> ORDERitems = new List<OrderItem>();
            foreach (var cartItem in cartItems)
            {
                ORDERitems.Add(
                    new OrderItem()
                    {
                        OrderId = 4,
                        ProductId = cartItem.ProductId,
                        //Price = cartItem.Price,
                        Quantity = cartItem.Quantity,
                    });
            }

            var order = new Order
            {
                Id = 4,
                UserId = userId,
                //Items = ORDERitems,
                //TotalPrice = cartItems.Sum(ci => ci.Price * ci.Quantity),
                //Status = "Pending"
            };
            

            var sss =_context.Orders.Add(order);


            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}