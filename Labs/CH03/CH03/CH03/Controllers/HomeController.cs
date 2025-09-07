using System.Diagnostics;
using CH03.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH02.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var quoteModel = new PriceQuotation();
            quoteModel.Subtotal = 0;
            ViewBag.Message = "Price Quotation Page";
            return View(quoteModel);
        }

        [HttpPost]

        public IActionResult Index(PriceQuotation quoteModel)
        {
            if (ModelState.IsValid)
            {
                return View(quoteModel);
            }
            else
            {
                quoteModel.Subtotal = 0;
            }
            return View(quoteModel);
        }
    }
}
