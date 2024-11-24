using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using e_commerce.Models;

//namespace e_commerce.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
//        {
//            _signInManager = signInManager;
//            _userManager = userManager;
//        }

//        // Login action
//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(LoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Checkout", "ShoppingCart");
//                }
//                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//            }
//            return View(model);
//        }

//        // Register action
//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Register(RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
//                var result = await _userManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    await _signInManager.SignInAsync(user, isPersistent: false);
//                    return RedirectToAction("Checkout", "ShoppingCart");
//                }
//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }
//            }
//            return View(model);
//        }
//    }
//}
