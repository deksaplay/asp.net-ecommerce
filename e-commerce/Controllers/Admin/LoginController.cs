using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_commerce.Controllers.Admin
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                // Simulasi pengecekan login (gunakan logika autentikasi di sini)
                if (username == "admin" && password == "password123") // Ganti dengan autentikasi nyata
                {
                    // Redirect ke halaman dashboard atau halaman utama setelah login sukses
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View();
        }
    }
}
