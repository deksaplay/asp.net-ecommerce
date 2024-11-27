using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using e_commerce.Models;
using e_commerce.Data;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
namespace e_commerce.Controllers

 public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Customer customer)
    {
        if (ModelState.IsValid)
        {
            // Hashing password before saving
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(customer.Password);

            customer.Password = hashedPassword;

            _context.Add(customer);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToAction(nameof(Login)); // Redirect to login page after registration
        }

        return View(customer);
    }
}
}