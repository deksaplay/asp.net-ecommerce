﻿using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

using System.Threading.Tasks;

namespace e_commerce.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly CheckoutService _checkoutService;

        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

       
    }
}
