using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace e_commerce.Controllers
{
    public class PromotionController : BaseController
    {
        private readonly PromotionService _promotionService;

        public PromotionController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Promotion>> GetAll()
        {
            return await _promotionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Promotion> GetById(int id)
        {
            return await _promotionService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Promotion> Create([FromBody] Promotion promotion)
        {
            return await _promotionService.CreateAsync(promotion);
        }

        [HttpPut("{id}")]
        public async Task<Promotion> Update(int id, [FromBody] Promotion promotion)
        {
            promotion.Id = id;
            return await _promotionService.UpdateAsync(promotion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _promotionService.DeleteAsync(id);
            return NoContent();
        }
    }
}