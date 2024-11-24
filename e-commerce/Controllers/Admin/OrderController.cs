using e_commerce.Models;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


////namespace e_commerce.Controllers.Admin
////{
    //public class OrderController : BaseController
    //{
    //    private readonly OrderService _orderService;

    //    }

    //    public IActionResult Index()
    //    {
//            var orders = _orderService.GetAllOrders();
//            return View(orders);
//        }

//        public IActionResult Details(int id)
//        {
//            var order = _orderService.GetOrderById(id);
//            if (order == null)
//            {
//                return NotFound();
//            }
//            return View(order);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Order order)
//        {
//            if (ModelState.IsValid)
//            {
//                _orderService.AddOrder(order);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(order);
//        }
//    }
//}