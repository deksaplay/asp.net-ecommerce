using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_commerce.Controllers
{
    public class InventoryController : BaseController
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _inventoryService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Inventory> GetById(int id)
        {
            return await _inventoryService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Inventory> Create([FromBody] Inventory inventory)
        {
            return await _inventoryService.CreateAsync(inventory);
        }

        [HttpPut("{id}")]
        public async Task<Inventory> Update(int id, [FromBody] Inventory inventory)
        {
            inventory.Id = id;
            return await _inventoryService.UpdateAsync(inventory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
