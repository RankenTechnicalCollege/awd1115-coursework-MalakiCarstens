
using Microsoft.AspNetCore.Mvc;
using TripLog2.Models.DataAccess;
using TripLog2.Models.DomainModels;

namespace TripLog2.Controllers
{
    public class TripController : Controller
    {
        private Repository<Trip> tripData { get; set; }
        private Repository<Destination> destinationData { get; set; }
        private Repository<Accomodation> accomodationData { get; set; }
        private Repository<Activity> activityData { get; set; }
        public TripController(TripLog2Context ctx)
        {
            tripData = new Repository<Trip>(ctx);
            destinationData = new Repository<Destination>(ctx);
            accomodationData = new Repository<Accomodation>(ctx);
            activityData = new Repository<Activity>(ctx);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}