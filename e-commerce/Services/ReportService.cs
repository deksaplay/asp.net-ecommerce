using e_commerce.Data;
using e_commerce.Models;
using System.Threading.Tasks;
using e_commerce.Base;
namespace e_commerce.Services
{
    public class ReportService : BaseService<Report>
    {
        public ReportService(ApplicationDbContext context) : base(context)
        {
        }
    }
}