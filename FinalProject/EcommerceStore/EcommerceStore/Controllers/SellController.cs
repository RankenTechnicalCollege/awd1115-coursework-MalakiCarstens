using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{
    public class SellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
