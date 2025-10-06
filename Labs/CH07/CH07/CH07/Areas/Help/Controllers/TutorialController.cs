using Microsoft.AspNetCore.Mvc;

namespace CH07.Areas.Help.Controllers
{
    public class TutorialController : Controller
    {
        [Area("Help")]
        public IActionResult Index(int id=1)
        {
            string page = id switch
            {
                1 => "Page1",
                2 => "Page2",
                3 => "Page3"
            };
            return View(page);
        }
    }
}
