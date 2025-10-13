using HOT3.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TableController : Controller
    {
        private readonly StoreContext context;
        public TableController(StoreContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var tables = context.Tables.ToList();
            return View(tables);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            Table table;

            if (id == null || id == 0)
            {
                table = new Table();
            }
            else
            {
                table = context.Tables.Find(id);

                if (table == null)
                {
                    return NotFound();
                }
            }

            return View("AddEdit", table);
        }

        [HttpPost]
        public IActionResult AddEdit(Table table)
        {
            if (ModelState.IsValid)
            {
                if (table.Id == 0)
                {
                    context.Tables.Add(table);
                }
                else
                {
                    context.Tables.Update(table);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", table);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var table = context.Tables.Find(id);
            if (table != null)
            {
                return View(table);
            }

            return RedirectToAction("List");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var table = context.Tables.Find(id);
            if (table != null)
            {
                context.Tables.Remove(table);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
