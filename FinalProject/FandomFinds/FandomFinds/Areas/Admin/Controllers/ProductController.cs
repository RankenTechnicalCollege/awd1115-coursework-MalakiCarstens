using Microsoft.AspNetCore.Mvc;
using FandomFinds.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Authorization;


namespace FandomFinds.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ShopContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<Brand> _brands;
        private readonly Repository<Product> _products;
       

        public ProductController(ShopContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _brands = new Repository<Brand>(context);
            _webHostEnvironment = webHostEnvironment;

            _products = new Repository<Product>(context);
          
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _products.GetAllAsync());
        //}

        public async Task<IActionResult> List()
        {
            var products = await _products.GetAllAsync();
            var brands = await _brands.GetAllAsync();
            var reviews = await _context.ProductReviews.ToListAsync();

            var model = new ProductViewModel
            {
                Products = products,
                Brands = brands,
                Reviews = reviews
            };

            return View("List", model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Brands = await _brands.GetAllAsync();

            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Product());
            }

            ViewBag.Operation = "Edit";
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Product product)
        {
            ViewBag.Brands = await _brands.GetAllAsync();

            if (!ModelState.IsValid)
                return View(product);

            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid() + "_" + product.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(stream);
                }

                product.ImageUrl = "/images/" + uniqueFileName;
            }
            if (product.ProductId == 0)
            {
                await _products.AddAsync(product);
                TempData["SuccessMessage"] = "Product created successfully!";
            }
            else
            {
                var existing = await _products.GetByIdAsync(product.ProductId, new QueryOptions<Product>());

                if (existing == null)
                    return NotFound();

                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;
                existing.Stock = product.Stock;
                existing.BrandId = product.BrandId;

                if (product.ImageFile != null)
                {
                    existing.ImageUrl = product.ImageUrl;
                }

                await _products.UpdateAsync(existing);

                TempData["SuccessMessage"] = "Product updated successfully!";
            }

            return RedirectToAction("List");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _products.DeleteAsync(id);
                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            catch
            {
                TempData["ErrorMessage"] = "Error deleting product.";
            }

            return RedirectToAction("List");
        }
    }
}

//OLD CODE
//    [Area("Admin")]
//    public class ProductController : Controller
//    {
//        private readonly ShopContext _context;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly Repository<Category> _categories;
//        private readonly IRepository<Product> _products;

//        public ProductController(ShopContext context, IWebHostEnvironment webHostEnvironment)
//        {
//            _context = context;
//            _categories = new Repository<Category>(context);
//            _products = new Repository<Product>(context);
//            _webHostEnvironment = webHostEnvironment;

//        }

//        public async Task<IActionResult> Index()
//        {

//            return View(await _products.GetAllAsync());
//        }



//        public IActionResult List(string name= "all")
//        {
//            List<Product> products;
//             if (name.Equals("all"))
//            {
//                products = _context.Products.ToList();
//            }
//            else
//            {
//                products = _context.Products.Where(p => p.Name == name).ToList();
//            }

//            var brands = _context.Brands.ToList();
//            var reviews = _context.ProductReviews.ToList();

//            var viewModel = new ProductViewModel
//            {
//                Products = products,
//                Brands = brands,
//                Reviews = reviews
//            };


//            return View(viewModel);


//        }

//        [HttpGet]
//        public IActionResult Add(int? id)
//        {
//            if (id.HasValue)
//            {
//                var product = _context.Products.Find(id);
//                if(product != null)
//                {

//                    return View("AddEdit", product);
//                }

//            }
//            return View("AddEdit", new Product());
//        }
//        [HttpPost]
//        public IActionResult Add(Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                if (product.ProductId == 0)
//                {
//                    _context.Products.Add(product);
//                    TempData["SuccessMessage"] = "Product successfully created!";
//                }
//                else
//                {
//                    _context.Products.Update(product);
//                    TempData["SuccessMessage"] = "Product successfully updated!";
//                }

//                _context.SaveChanges();
//                return RedirectToAction("List");
//            }
//            return View("AddEdit", product);
//        }


//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            var product = _context.Products.Find(id)
//                ;
//            if (product != null)
//            {
//                return View(product);
//            }
//            return RedirectToAction("List");
//        }
//        [HttpPost]
//        public IActionResult DeleteProduct(int id)
//        {
//            var product = _context.Products.Find(id);
//            if (product != null)
//            {
//                _context.Products.Remove(product);
//                _context.SaveChanges();
//                TempData["SuccessMessage"] = "Product successfully deleted!";
//            }
//            return RedirectToAction("List");
//        }


//    }
//}
