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

      
    }
}