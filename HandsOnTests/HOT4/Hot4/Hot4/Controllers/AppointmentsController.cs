using Hot4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hot4.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _context.Appointments.Include(a => a.Customer).OrderBy(a => a.StartDateTime).ToListAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();

            if (!ModelState.IsValid)
                return View(appointment);

            if (appointment.StartDateTime.Minute != 0 || appointment.StartDateTime.Second != 0)
            {
                ModelState.AddModelError(nameof(appointment.StartDateTime),
                    "Appointment must start exactly on the hour");
                return View(appointment);
            }

            if (appointment.StartDateTime <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(appointment.StartDateTime),
                    "Appointment must be scheduled for a future date and time.");
                return View(appointment);
            }

            var exists = await _context.Appointments.AnyAsync(a => a.StartDateTime == appointment.StartDateTime);
            if (exists)
            {
                ModelState.AddModelError(nameof(appointment.StartDateTime),
                    "That date and time slot is already taken. Please choose another hour.");
                return View(appointment);
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Appointment created successfully.";
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var appt = await _context.Appointments.Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (appt == null)
            {
                return NotFound();
            }
            return View(appt);
        }


    }
}
