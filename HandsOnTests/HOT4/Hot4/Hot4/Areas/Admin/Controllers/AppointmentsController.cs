using Hot4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hot4.Areas.Admin.Controllers
{
    [Area("Admin")]
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


        public async Task<IActionResult> Edit(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt == null)
            { 
                return NotFound();
            }
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();
            return View(appt);
        }

        
        [HttpPost]
     
        public async Task<IActionResult> Edit(int id, Appointment model)
        {
            if (id != model.Id) return BadRequest();

            ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();

            if (!ModelState.IsValid) return View(model);

           
            if (model.StartDateTime.Minute != 0 || model.StartDateTime.Second != 0)
            {
                ModelState.AddModelError(nameof(model.StartDateTime),
                    "Appointment must start exactly on the hour (minutes and seconds must be 00).");
                return View(model);
            }

            
            if (model.StartDateTime <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(model.StartDateTime),
                    "Appointment must be scheduled for a future date and time.");
                return View(model);
            }

            
            var exists = await _context.Appointments
                .AnyAsync(a => a.StartDateTime == model.StartDateTime && a.Id != model.Id);

            if (exists)
            {
                ModelState.AddModelError(nameof(model.StartDateTime),
                    "That date and time slot is already taken by another appointment.");
                return View(model);
            }

            try
            {
                _context.Appointments.Update(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Appointment updated.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. The selected time slot might be taken.");
                return View(model);
            }
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var appt = await _context.Appointments.Include(a => a.Customer).FirstOrDefaultAsync(a => a.Id == id);
            if (appt == null) return NotFound();
            return View(appt);
        }

      
        [HttpPost, ActionName("Delete")]
    
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt == null) return NotFound();
            _context.Appointments.Remove(appt);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Appointment deleted.";
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var appt = await _context.Appointments.Include(a => a.Customer).FirstOrDefaultAsync(a => a.Id == id);
            if (appt == null)
            {
                return NotFound();
            }
            return View(appt);
        }
    }
}
    
