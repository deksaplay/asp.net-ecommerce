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

       
    }
}
