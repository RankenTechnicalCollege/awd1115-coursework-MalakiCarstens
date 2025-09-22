using HOT2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;


namespace HOT2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> List()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var productDelete = await _context.Products.FindAsync(id);
            return View(productDelete);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            Product product;
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                product = new Product();
            }
            else
            {
                ViewBag.Operation = "Edit";
                product = await _context.Products.FindAsync(id);
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", product?.CategoryID);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(Product product)
        {
            ViewBag.Operation = product.ProductId == 0 ? "Add" : "Edit";
            if (product.ProductId == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                _context.Products.Update(product);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));

        } 
        public IActionResult Index()
        {
            return View();
        }
    }
}
