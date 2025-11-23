
using FandomFinds.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NuGet.Packaging.PackagingConstants;

namespace FandomFinds.Controllers
{
    [Authorize]
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ShopContext _context;

        public OrdersController(ShopContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("")]
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }


        [HttpGet("{id}/{slug}")]
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        [HttpGet("create")]
        // GET: Orders/Create
        public IActionResult Create()
        {
            //var userId = _userManager.GetUserId(User);

            //var order = new Order { IdentityUserId = userId };

            return View();
        }


        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDate,TotalAmount,OrderName")] Order order)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(order);

            order.ApplicationUserId = _userManager.GetUserId(User);

            // Ensure slug-safe OrderName (kebab-case)
            order.OrderName = order.OrderName?.Trim().ToLower().Replace(" ", "-");

            _context.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        [HttpGet("edit/{id}/{slug}")]
        public async Task<IActionResult> Edit(int? id, string slug)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost("edit/{id}/{slug}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string slug, [Bind("OrderId,OrderDate,TotalAmount,OrderName,ApplicaitonUserId")] Order order)
        {
            if (id != order.OrderId) return NotFound();

            if (!ModelState.IsValid) return View(order);

            order.OrderName = order.OrderName?.Trim().ToLower().Replace(" ", "-");

            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(o => o.OrderId == order.OrderId)) return NotFound();
                else throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}/{slug}")]
        public async Task<IActionResult> Delete(int? id, string slug)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost("delete/{id}/{slug}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null) _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("shopping")]
        [AllowAnonymous]
        public async Task<IActionResult> Shopping(string searchString, int pageNumber = 1)
        {
            int pageSize = 4;
            IQueryable<Product> productsQuery = _context.Products;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim().ToLower();

                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(searchString) ||
                    p.Description.ToLower().Contains(searchString) ||
                    (p.Brand != null && p.Brand.Name.ToLower().Contains(searchString))
                );
            }
            var paginatedProducts = await PaginatedList<Product>.CreateAsync(productsQuery.AsNoTracking(), pageNumber, pageSize);

            return View(paginatedProducts);
        }

        [HttpGet("cart")]
        [Authorize]
        public IActionResult Cart()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null)
            {
                model = new OrderViewModel
                {
                    OrderItems = new List<OrderItemViewModel>(),
                    TotalAmount = 0
                };
            }

            return View(model);
        }



        [HttpPost("additem")]
        public async Task<IActionResult> AddItem(int productId, int quantity = 1)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel") ?? new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>()
            };

         
            var existingItem = model.OrderItems.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                model.OrderItems.Add(new OrderItemViewModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }

            model.TotalAmount = model.OrderItems.Sum(x => x.Price * x.Quantity);


            HttpContext.Session.Set("OrderViewModel", model);

            TempData["SuccessMessage"] = $"{product.Name} added to cart!";
            return RedirectToAction("Shopping");
        }

        [HttpPost("placeorder")]
        public async Task<IActionResult> PlaceOrder()
        {
            var cart = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");
            if (cart == null || !cart.OrderItems.Any())
            {
                return RedirectToAction("Cart");
            }

            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = cart.TotalAmount,
                ApplicationUserId = _userManager.GetUserId(User),
                OrderItems = cart.OrderItems.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("OrderViewModel");
            return RedirectToAction("ViewOrders");
        }
        [HttpGet("vieworders")]
        public async Task<IActionResult> ViewOrders()
        {
            var userId = _userManager.GetUserId(User);
            var userOrders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.ApplicationUserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(userOrders);
        }
    }
}
    

