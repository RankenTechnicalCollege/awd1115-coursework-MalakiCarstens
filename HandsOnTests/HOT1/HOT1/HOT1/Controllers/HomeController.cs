using System.Diagnostics;
using HOT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public IActionResult Index()
        {
            DistanceConvert distanceConvert = new DistanceConvert();
            distanceConvert.Inches = 0;
            return View(distanceConvert);
        }


        [HttpPost]
        public IActionResult Index(DistanceConvert m)
        {
            if (ModelState.IsValid)
            {
                return View(m);
            }
            return View(m);
        }
    }
}
