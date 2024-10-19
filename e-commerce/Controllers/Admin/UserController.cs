using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace e_commerce.Controllers.Admin
{
    public class UserController : BaseController
    {
        private readonly UserService _UserService;

        public UserController(UserService UserService)
        {
            _UserService = UserService;
        }


        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}