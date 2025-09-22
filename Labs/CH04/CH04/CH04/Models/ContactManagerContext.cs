using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace CH04.Models
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext(DbContextOptions<ContactManagerContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<ContactManager> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "School" },
                new Category { Id = 2, Name = "Work" },
                new Category { Id = 3, Name = "Family" },
                new Category { Id = 4, Name = "Friend" },
                new Category { Id = 5, Name = "Neighbor" },
                new Category { Id = 6, Name = "Online" }
                );
            modelBuilder.Entity<ContactManager>().HasData(
                new ContactManager
                {
                    Id = 1,
                    FirstName = "David",
                    LastName = "Smith",
                    PhoneNum = "371-913-0183",
                    Email = "RealDDavid@gmail.com",
                    Added = new DateTime(2023, 7, 20),
                    CategoryId = 1,
                },
                new ContactManager
                {
                    Id = 2,
                    FirstName = "Hannah",
                    LastName = "Whire",
                    PhoneNum = "371-768-1413",
                    Email = "MsHannahWhire@gmail.com",
                    Added = new DateTime(2024, 3, 5),
                    CategoryId = 2,
                },
                new ContactManager
                {
                    Id = 3,
                    FirstName = "Aaron",
                    LastName = "Paul",
                    PhoneNum = "371-587-7821",
                    Email = "NotThatAaronPaul@gmail.com",
                    Added = new DateTime(2019, 5, 9),
                    CategoryId = 3,

                }
                );
        }
    }
}
