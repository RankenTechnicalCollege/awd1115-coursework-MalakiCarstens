using Ch08.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch08.Controllers
{
    public class AppTripLogController : Controller
    {
        private readonly TripContext _context;

        public AppTripLogController(TripContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.SubHeader = "My Trip Log";
            var trips = _context.TripLogs.ToList();
            return View(trips);
        }

        [HttpGet]
        public IActionResult Add1()
        {
            ViewBag.SubHeader = "Add a Trip Destination and Dates";
            return View();
        }
        [HttpPost]
        public IActionResult Add1(AppTripLog trip)
        {
            if (ModelState.IsValid)
            {
                TempData["Destination"] = trip.Destination;
                TempData["StartDate"] = trip.StartDate.ToShortDateString();
                TempData["EndDate"] = trip.EndDate.ToShortDateString();
                TempData["Accommodations"] = trip.Accommodation;
                return RedirectToAction("Add2");
            }
            ViewBag.SubHeader = "Add a Trip Destination and Dates";
            return View(trip);
        }

        [HttpGet]
        public IActionResult Add2()
        {
            var accommodations = TempData["Accommodations"]?.ToString() ?? "";
            ViewBag.SubHeader = $"Add Info for {accommodations}";
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public IActionResult Add2(AppTripLog trip)
        {
            TempData["AccommodationPhone"] = trip.AccommodationPhone;
            TempData["AccommodationEmail"] = trip.AccommodationEmail;
            TempData.Keep();
            return RedirectToAction("Add3");

        }
        [HttpGet]
        public IActionResult Add3()
        {
            ViewBag.SubHeader = $"Add Activities for {TempData["Destination"]}";
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult Add3(AppTripLog trip)
        {
           
                var newTrip = new AppTripLog
                {
                    Destination = TempData["Destination"]?.ToString() ?? "",
                    StartDate = DateTime.Parse(TempData["StartDate"]?.ToString() ?? ""),
                    EndDate = DateTime.Parse(TempData["EndDate"]?.ToString() ?? ""),
                    Accommodation = TempData["Accommodations"]?.ToString() ?? "",
                    AccommodationPhone = TempData["AccommodationPhone"]?.ToString() ?? "",
                    AccommodationEmail = TempData["AccommodationEmail"]?.ToString() ?? "",
                    Activity1 = trip.Activity1,
                    Activity2 = trip.Activity2,
                    Activity3 = trip.Activity3
                };
                _context.TripLogs.Add(newTrip);
                _context.SaveChanges();

                TempData.Clear();
                TempData["SuccessMessage"] = $"Trip to {newTrip.Destination} added.";
                return RedirectToAction("Index", "Home");
            }
           
        
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }

    }
}
