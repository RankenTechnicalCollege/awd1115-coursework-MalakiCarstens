using Hot4.Models;
using Microsoft.AspNetCore.Mvc;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;
    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
 
    public async Task<IActionResult> Create(Customer customer)
    {
        if (!ModelState.IsValid)
            return View(customer);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Customer created successfully.";
        return RedirectToAction("Index", "Customers");
    }

    public IActionResult Index()
    {
        var list = _context.Customers.ToList();
        return View(list);
    }
}

