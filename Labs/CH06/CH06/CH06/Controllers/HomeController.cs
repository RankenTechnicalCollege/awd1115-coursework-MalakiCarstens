using System.Diagnostics;
using CH06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CH06.Controllers
{
    public class HomeController : Controller
    {
        private FaqsContext _context { get; set; }
        public HomeController(FaqsContext ctx)
        {
            _context = ctx;
        }
        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("Category/{category}")]
        [Route("/")]

       

        public IActionResult Index(string topic,string category)
        {
            var faqs = _context.FAQs.Include(f => f.Category).Include(f => f.Topic).OrderBy(f => f.Question).ToList();

            ViewBag.Topics = _context.Topics.OrderBy(t => t.Name).ToList();
            ViewBag.Categories = _context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.SelectTopic = topic;
            
            if(!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.Topic.TopicId == topic).ToList(); 
            }
            if(!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(faqs => faqs.Category.CategoryId == category).ToList();
            }
            return View(faqs);
        }

    }
}
