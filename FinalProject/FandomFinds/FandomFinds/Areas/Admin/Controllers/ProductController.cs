using Microsoft.AspNetCore.Mvc;
using FandomFinds.Models;
using Microsoft.EntityFrameworkCore;


namespace FandomFinds.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

 

        public IActionResult List(string name= "all")
        {
            List<Product> products;
             if (name.Equals("all"))
            {
                products = _context.products.ToList();
            }
            else
            {
                products = _context.products.Where(p => p.Name == name).ToList();
            }
             return View(products);

        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                var product = _context.products.Find(id);
                if(product != null)
                {

                    return View("AddEdit", product);
                }
            
            }
            return View("AddEdit", new Product());
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    _context.products.Add(product);
                }
                else
                {
                    _context.products.Update(product);
                }

                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", product);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.products.Find(id)
                ;
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.products.Find(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }


    }
}
