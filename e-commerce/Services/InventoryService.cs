using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;
namespace e_commerce.Services
{
    public class InventoryService : BaseService<Inventory>
    {
        public InventoryService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
        }
    }
}