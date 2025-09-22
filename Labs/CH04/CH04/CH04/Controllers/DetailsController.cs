using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CH04.Models;

namespace CH04.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ContactManagerContext _context;
        public DetailsController(ContactManagerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            var contact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

    }
    //public IActionResult Index()
    //{
    //    return View();
    //}
}

