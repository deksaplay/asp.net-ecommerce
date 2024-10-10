using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_commerce.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

     
       
    }
}