using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
