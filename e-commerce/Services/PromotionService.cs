using e_commerce.Data;
using e_commerce.Models;
using System.Threading.Tasks;
using e_commerce.Base;
namespace e_commerce.Services
{
    public class PromotionService : BaseService<Promotion>
    {
        public PromotionService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
        }
    }
}