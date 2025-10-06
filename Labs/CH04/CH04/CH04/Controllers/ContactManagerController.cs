using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CH04.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CH04.Controllers
{
    public class ContactManagerController : Controller
    {
        private readonly ContactManagerContext? _context;
        public ContactManagerController(ContactManagerContext? context)
        {
            _context = context;
        }
        [Route("contacts")]
        public async Task<IActionResult> List()
        {
            var contacts = await _context.Contacts.Include(c => c.Category).ToListAsync();
            return View(contacts);
        }

        [HttpGet("delete/{id}/{slug}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteContact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);


            if (deleteContact == null)
            {
                return View("Error");
            }
            return View(deleteContact);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ContactManager contact)
        {
            var contactToDelete = await _context.Contacts.FindAsync(contact.Id);
            if (contactToDelete == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contactToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }



        [HttpGet("edit/{id}/{slug}")]
        public async Task<IActionResult> AddEdit(int id)
        {
           if (id == 0)
            {
                ViewBag.Categories = new SelectList(await _context.Category.ToListAsync(), "Id", "Name");
                ViewBag.Operation = "Add";
                return View(new ContactManager { Added = DateTime.Now});
            }
           else
            {
                var editContact = await _context.Contacts.FindAsync(id);
                ViewBag.Categories = new SelectList(await _context.Category.ToListAsync(), "Id", "Name", editContact?.CategoryId);
                ViewBag.Operation = "Edit";
                return View(editContact);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(ContactManager contact)
        {
            ViewBag.Operation = contact.Id == 0 ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if(contact.Id == 0)
                {
                    _context.Contacts.Add(contact);
                }
                else
                {
                    _context.Contacts.Update(contact);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(contact);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
