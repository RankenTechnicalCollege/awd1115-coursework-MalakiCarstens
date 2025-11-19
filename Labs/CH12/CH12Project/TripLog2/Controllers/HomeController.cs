using Microsoft.AspNetCore.Mvc;
using TripLog2.Models;
using TripLog2.Models.DataAccess;
using TripLog2.Models.DomainModels;
using TripLog2.Models.Utilities;

namespace TripLog2.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Trip> data { get; set; }
        private Repository<Destination> destinationData { get; set; }
        private Repository<Accomodation> accomodationData { get; set; }
        private Repository<Models.DomainModels.Activity> activityData { get; set; }

        public HomeController(TripLog2Context ctx)
        {
            data = new Repository<Trip>(ctx);
            destinationData = new Repository<Destination>(ctx);
            accomodationData = new Repository<Accomodation>(ctx);
            activityData = new Repository<Activity>(ctx);
        }
        public IActionResult Index()
        {
            var options = new QueryOptions<Trip>
            {
                Includes = "Destination, Accomodation, Activities",
                OrderBy = t => t.StartDate!
            };
            var trips = data.List(options);
            return View(trips);
        }
        [HttpGet]
        public IActionResult Add(string? id)
        {
            if (string.IsNullOrEmpty(id) || id == "Page1")
            {
                return View("Page1", new Trip());
            }
            if (id == "Page2")
            {
                Trip? trip = TempData.Get<Trip>("Trip");
                if (trip == null)
                    return RedirectToAction("Add", new { id = "Page1" });

                ViewBag.Activities = activityData.List(new QueryOptions<Activity>());
                ViewBag.Destinations = destinationData.List(new QueryOptions<Destination>());
                ViewBag.Accomodations = accomodationData.List(new QueryOptions<Accomodation>());
                TempData.Keep("Trip");
                return View("Page2", trip);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult Page1(Trip trip)
        {
            if (!ModelState.IsValid)
                return View("Page1", trip);
            var dest = destinationData
            .List(new QueryOptions<Destination>())
            .FirstOrDefault(d => d.Name == trip.DestinationLocation);

            if (dest == null)
            {
                dest = new Destination
                {
                    Name = trip.DestinationLocation
                };
                destinationData.Insert(dest);
                destinationData.Save();
            }
            trip.DestinationId = dest.DestinationId;
            var accomm = accomodationData
             .List(new QueryOptions<Accomodation>())
               .FirstOrDefault(a => a.Name == trip.AccomodationName);
            if (accomm == null)
            {
                accomm = new Accomodation
                { Name = trip.AccomodationName };
                accomodationData.Insert(accomm);
                accomodationData.Save();
            }
            trip.AccomodationId = accomm.AccomodationId;
            TempData.Put("Trip", trip);
            return RedirectToAction("Add", new { id = "Page2" });
        }

        [HttpPost]

        public IActionResult Page2(Trip trip, string[] selectedActivities)
        {
            Trip? newTrip = TempData.Get<Trip>("Trip");

            if (newTrip == null)
                return RedirectToAction("Add", new { id = "Page1" });

            trip.DestinationId = newTrip.DestinationId;
            trip.AccomodationId = newTrip.AccomodationId;
            trip.StartDate = newTrip.StartDate;
            trip.EndDate = newTrip.EndDate;
            trip.AccomodationName = newTrip.AccomodationName;
            trip.Activities = selectedActivities
            .Where(a => !string.IsNullOrEmpty(a))
            .Select(a => new Activity { Name = a })
            .ToList();

            data.Insert(trip);
            data.Save();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var option = new QueryOptions<Trip>
            {
                Includes = "Destination, Accomodation, Activities",
                Where = t => t.TripId == id
            };
            var trip = data.Get(option);

            if (trip == null)
            {
                return RedirectToAction("Index");
            }
            data.Delete(trip);
            data.Save();
            var destName = trip.Destination?.Name  ?? trip.DestinationLocation   ?? "destination";

            TempData["message"] = $"Trip to {destName} deleted";
            return RedirectToAction("Index");
        }

    }
}
