using FandomFinds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FandomFinds.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductInformationController : Controller
    {
        private readonly ShopContext _context;

        public ProductInformationController(ShopContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductInformation
        public async Task<IActionResult> Index()
        {
            var model = await _context.ProductInformation
                                      .Include(pi => pi.Product)
                                      .Include(pi => pi.Information)
                                      .ToListAsync();
            return View(model);
        }

        public IActionResult AddEdit(int? productId, int? informationId)
        {
         
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "Name");

            Information info;

            if (informationId.HasValue)
            {
                info = _context.Information.Find(informationId.Value);
                if (info == null) return NotFound();
            }
            else
            {
                info = new Information();
            }

            return View(info);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(int productId, Information info)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Products = new SelectList(_context.Products, "ProductId", "Name");
                return View(info);
            }

            if (info.InformationId == 0)
            {
                _context.Information.Add(info);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Information.Update(info);
                await _context.SaveChangesAsync();
            }
            var existing = await _context.ProductInformation
                                         .FirstOrDefaultAsync(pi => pi.ProductId == productId && pi.InformationId == info.InformationId);

            if (existing == null)
            {
                var junction = new ProductInformation
                {
                    ProductId = productId,
                    InformationId = info.InformationId
                };
                _context.ProductInformation.Add(junction);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int productId, int informationId)
        {
            var pi = await _context.ProductInformation
                                   .Include(x => x.Product)
                                   .Include(x => x.Information)
                                   .FirstOrDefaultAsync(x => x.ProductId == productId && x.InformationId == informationId);

            if (pi == null) return NotFound();

            return View(pi);
        }

        // POST: Admin/ProductInformation/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int productId, int informationId)
        {
            var pi = await _context.ProductInformation
                                   .FirstOrDefaultAsync(x => x.ProductId == productId && x.InformationId == informationId);

            if (pi != null)
            {
                _context.ProductInformation.Remove(pi);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}




