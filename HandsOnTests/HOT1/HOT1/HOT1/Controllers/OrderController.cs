using HOT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT1.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var shirt = new CrazyCrankShirts() { ShirtPrice = 15.00m, Tax = 0.08m};
            return View(shirt);
        }
        [HttpPost]
        public IActionResult Index(CrazyCrankShirts order)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message =
                      $"SubTotal: {order.CalculateSubTotal():C}  " +
                      $"Tax: {order.CalculateTax():C}  " +
                      $"Total: {order.CalculateTotal():C}";

            }
            return View(order);
        }
    }
}
