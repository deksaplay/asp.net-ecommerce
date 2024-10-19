using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers.Admin
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
