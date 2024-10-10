using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace e_commerce.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService _UserService;

        public UserController(UserService UserService)
        {
            _UserService = UserService;
        }

       
    }
}