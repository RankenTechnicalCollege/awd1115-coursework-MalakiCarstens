

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

namespace FandomFinds.Controllers
{
    [Authorize]
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ShopContext _context;

        public OrdersController(ShopContext context, UserManager<IdentityUser> userManager)
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

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDate,TotalAmount,OrderName")] Order order)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(order);

            order.IdentityUserId = _userManager.GetUserId(User);

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
        public async Task<IActionResult> Edit(int id, string slug, [Bind("OrderId,OrderDate,TotalAmount,OrderName,IdentityUserId")] Order order)
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

        // GET: /orders/shopping/
        [HttpGet("shopping")]
        [AllowAnonymous]
        public async Task<IActionResult> Shopping(string searchString, int pageNumber = 1)
        {
            int pageSize = 4; // Number of products per page
            IQueryable<Product> productsQuery = _context.Products;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim().ToLower();
                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(searchString) ||
                    p.Description.ToLower().Contains(searchString) ||
                    p.Brand.ToLower().Contains(searchString)
                );
            }

            var paginatedProducts = await PaginatedList<Product>.CreateAsync(productsQuery.AsNoTracking(), pageNumber, pageSize);

            return View(paginatedProducts);
        }



        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
