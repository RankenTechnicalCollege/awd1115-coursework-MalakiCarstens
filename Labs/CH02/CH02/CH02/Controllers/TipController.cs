using CH02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH02.Controllers
{
    public class TipCalculateController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var tipModel = new Page2Calc();
            tipModel.mealTotal = 0;
            ViewBag.Message = "Calculation Page";
            return View(tipModel);
        }

        [HttpPost]

        public IActionResult Index(Page2Calc tipModel)
        {
            if(ModelState.IsValid)
            {
                return View(tipModel);
            }
            else
            {
                tipModel.mealTotal = 0;
            }
                return View(tipModel);
        }
    }
}
