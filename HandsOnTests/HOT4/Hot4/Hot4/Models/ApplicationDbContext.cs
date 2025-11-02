using Microsoft.EntityFrameworkCore;

namespace Hot4.Models
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Username = "john_doe",
                    PhoneNumber = "123-456-7890"

                },
                new Customer
                {
                    Id = 2,
                    Username = "jane_smith",
                    PhoneNumber = "987-654-3210"
                },
                new Customer
                {
                    Id = 3,
                    Username = "alice_jones",
                    PhoneNumber = "555-123-4567"
                });
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    StartDateTime = new DateTime(2026, 9, 1, 10, 0, 0),
                    CustomerId = 1
                },
                new Appointment
                {
                    Id = 2,
                    StartDateTime = new DateTime(2026, 4, 2, 14, 0, 0),
                    CustomerId = 2
                },
                new Appointment
                {
                    Id = 3,
                    StartDateTime = new DateTime(2026, 7, 3, 9, 0, 0),
                    CustomerId = 3
                });





        }
    }
}
