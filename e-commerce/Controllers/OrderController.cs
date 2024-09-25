using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace e_commerce.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Order> GetById(int id)
        {
            return await _orderService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Order> Create([FromBody] Order order)
        {
            return await _orderService.CreateOrderAsync(order);
        }

        [HttpPut("{id}")]
        public async Task<Order> Update(int id, [FromBody] Order order)
        {
            order.Id = id;
            return await _orderService.UpdateAsync(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public async Task<Order> UpdateStatus(int id, [FromBody] string status)
        {
            return await _orderService.UpdateOrderStatusAsync(id, status);
        }
    }
}