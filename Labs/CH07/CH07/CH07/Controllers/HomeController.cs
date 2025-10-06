using System.Diagnostics;
using CH07.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH07.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

      
        public IActionResult Contact()
        {
            return View();
        }
    }
}
