using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FandomFinds.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
       
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
