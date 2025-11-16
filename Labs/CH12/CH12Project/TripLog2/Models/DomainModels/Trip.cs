using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TripLog2.Models.DomainModels
{
    public class Trip
    {

        public Trip() => Activities = new HashSet<Activity>();
        public int TripId { get; set; }

        public int DestinationId { get; set; }
        [ValidateNever]
        public Destination Destination { get; set; } = null!;

        [Required(ErrorMessage = "Please enter the date your trip starts.")]

        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the date your trip ends.")]

        public DateTime? EndDate {  get; set; }

        public int AccomodationId { get; set; }
        [ValidateNever]

        public Accomodation? Accomodation { get; set; } = null!;

      public ICollection<Activity> Activities { get; set; }
    }
}
