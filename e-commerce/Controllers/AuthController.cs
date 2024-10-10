using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using e_commerce.Base;


namespace e_commerce.Controllers
{
    public class AuthController : BaseController
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        
           
    }
}