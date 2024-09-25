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

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _UserService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<User> GetById(int id)
        {
            return await _UserService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<User> Create([FromBody] User user)
        {
            return await _UserService.CreateAsync(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the body.");
            }
            try
            {
                var updatedCustomer = await _UserService.UpdateAsync(user);
                if (updatedCustomer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while updating the customer.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _UserService.DeleteAsync(id);
            return NoContent();
        }
    }
}