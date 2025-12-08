using Microsoft.AspNetCore.Mvc;

namespace HOT3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
