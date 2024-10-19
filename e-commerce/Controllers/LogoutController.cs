using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
