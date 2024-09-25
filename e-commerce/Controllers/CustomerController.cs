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

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerService.GetAllAsync();
        }
   

        [HttpGet("{id}")]
        public async Task<Customer> GetById(int id)
        {
            return await _customerService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Customer> Create([FromBody] Customer customer)
        {
            return await _customerService.CreateAsync(customer);
        }

        [HttpPut("{id}")]
        public async Task<Customer> Update(int id, [FromBody] Customer customer)
        {
            customer.Id = id;
            return await _customerService.UpdateAsync(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
      
    }
}