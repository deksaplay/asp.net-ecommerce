using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers.Admin
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
