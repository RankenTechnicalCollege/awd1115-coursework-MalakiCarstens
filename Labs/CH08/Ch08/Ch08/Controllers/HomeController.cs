using System.Diagnostics;
using Ch08.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch08.Controllers
{
    public class HomeController : Controller
    {
      private readonly TripContext _context;
        public HomeController(TripContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SubHeader = "Welcome to the Trip Log App";
            var tripLogs = _context.TripLogs.ToList();
            return View(tripLogs);
        }

     
    }
}
