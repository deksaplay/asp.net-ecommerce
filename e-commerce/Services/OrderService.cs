using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using e_commerce.Base;
using static NuGet.Packaging.PackagingConstants;
namespace e_commerce.Services
{
    public class OrderService : BaseService<Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
            _context = context;
        }

        // Sample data
        _orders = new List<Order>
            {
                new Order { Id = 1, CustomerName = "John Doe", OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 100.00M },
                new Order { Id = 2, CustomerName = "Jane Smith", OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 200.00M }
            }
        

        public List<Order> GetAllOrders() => _context.Orders.ToList();

public Order GetOrderById(int id) => _context.Orders.Find(id);

public void AddOrder(Order order)
{
    _context.Orders.Add(order);
    _context.SaveChanges();
}
    }
}