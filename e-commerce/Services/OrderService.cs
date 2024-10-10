using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using e_commerce.Base;
namespace e_commerce.Services
{
    public class OrderService : BaseService<Order>
    {
        public OrderService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            //order.Status = "Created";
            return await CreateAsync(order);
        }

        public async Task<Order> UpdateOrderStatusAsync(int id, string status)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                //order.Status = status;
                await UpdateAsync(order);
            }
            return order;
        }
    }
}