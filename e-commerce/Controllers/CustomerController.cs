using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace e_commerce.Controllers
{
    public class CustomerController :BaseController 
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

      
      
    }
}