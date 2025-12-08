using Microsoft.AspNetCore.Mvc;
using HOT3.Models;

namespace HOT3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;
        private List<ShoppingCartItem> _shoppingCartItems;
        public ShoppingCartController(StoreContext context)
        {
            _context = context;
            _shoppingCartItems = new List<ShoppingCartItem>();
        }

        public IActionResult Index()
        {
            return View();
        }
         public IActionResult AddToCart(int id)
        {
            var tableToAdd = _context.Tables.Find(id);
            if (tableToAdd == null)
            {
                return NotFound();
            }
            var ShoppingCartItem = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var existingCartItem = _shoppingCartItems.FirstOrDefault(item => item.Table.Id == id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                ShoppingCartItem.Add(new ShoppingCartItem
                {
                    Table = tableToAdd,
                    Quantity = 1
                });
            }
            HttpContext.Session.Set("Cart", ShoppingCartItem);
            TempData["CartMessage"] = $"{tableToAdd.Name} has been added to your cart.";
            return RedirectToAction("ViewCart");
        }
            
        public IActionResult ViewCart()
        {
            var ShoppingCartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var cartViewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems = ShoppingCartItems,
                ShoppingCartTotal = ShoppingCartItems.Sum(item => (item.Table?.Price ?? 0) * item.Quantity),
            };
            ViewBag.CartMessage = TempData["CartMessage"];
            return View(cartViewModel);
        }

        public IActionResult RemoveFromCart(int id)
        {
            var shoppingCartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var itemToRemove = shoppingCartItems.FirstOrDefault(item => item.Table.Id == id);
            TempData["CartMessage"] = $"{itemToRemove.Table.Name} has been removed from your cart.";
            if (itemToRemove != null)
            {
                if (itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {
                    shoppingCartItems.Remove(itemToRemove);
                }

            }
            HttpContext.Session.Set("Cart", shoppingCartItems);
            return RedirectToAction("ViewCart");
        }

        public IActionResult PurchaseItems()
        {
            var shoppingCartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            if (shoppingCartItems.Count == 0)
            {
                TempData["CartMessage"] = "Your cart is empty.";
                return RedirectToAction("ViewCart");
            }
            foreach (var item in shoppingCartItems)
            {
                _context.Purchases.Add(new Purchase
                {
                    TableId = item.Table.Id,
                    Quantity = item.Quantity,
                    PurchaseDate = DateTime.Now,
                    TotalAmount = (item.Table?.Price ?? 0) * item.Quantity
                });
            }
            _context.SaveChanges();
            TempData["CartMessage"] = "Thank you for your purchase!";
            HttpContext.Session.Set("Cart", new List<ShoppingCartItem>());
            return RedirectToAction("ViewCart");
        }
    }
}
