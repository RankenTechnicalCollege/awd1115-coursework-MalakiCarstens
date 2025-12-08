using HOT3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOT3.Controllers
{
    public class TableController : Controller
    {
        private readonly StoreContext _context;
        public TableController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? brand)
        {
            var desks = _context.Tables.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                desks = desks.Where(t => t.Brand.ToLower() == brand.ToLower());
                ViewBag.SelectedBrand = brand;
            }

            return View(desks.ToList());
        }

    }
}
