using Microsoft.EntityFrameworkCore;
namespace Ch08.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {
        }
        public DbSet<AppTripLog> TripLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppTripLog>().HasData(
                new AppTripLog
                {
                    Id = 1,
                    Destination = "New York City",
                    StartDate = new DateTime(2023, 5, 1),
                    EndDate = new DateTime(2023, 5, 7),
                    Accommodation = "Grand Hotel",
                    AccommodationPhone = "555-1234",
                    AccommodationEmail = "Grand-Hotel@gmail.com",
                    Activity1 = "Statue of Liberty",
                    Activity2 = "Broadway Show",
                    Activity3 = "Central Park"

                },
                new AppTripLog
                {
                    Id = 2,
                    Destination = "Los Angeles",
                    StartDate = new DateTime(2023, 6, 10),
                    EndDate = new DateTime(2023, 6, 15),
                    Accommodation = "Sunset Inn",
                    AccommodationPhone = "555-5678",
                    AccommodationEmail = "Sunset_Inn@hotelinfo.com",
                    Activity1 = "Hollywood Tour",
                    Activity2 = "Beach Day",
                    Activity3 = "Theme Park"
                });
        }
    }

    }

