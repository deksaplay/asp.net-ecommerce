using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
