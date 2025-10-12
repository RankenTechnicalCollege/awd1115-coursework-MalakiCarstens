using System.ComponentModel.DataAnnotations;

namespace Ch08.Models
{
    public class AppTripLog
    {
        public int Id { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Accommodation { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }
        public string? Activity1 { get; set; }
        public string? Activity2 { get; set; }
        public string? Activity3 { get; set; }


    }
}
