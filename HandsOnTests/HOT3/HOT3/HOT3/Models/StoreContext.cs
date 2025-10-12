using Microsoft.EntityFrameworkCore;

namespace HOT3.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Homary Cabstract Executive Office Desk",
                    Description = "This accent desk is made from hardwood and wrought metal, with one floating drawer.",
                    Price = 879.99m,
                    Brand = "Homary"


                },
                new Product
                {
                    Id = 2,
                    Name = "BYBLIGHT Capen",
                    Description = "Rectangular White wood 2-drawer computer desk",
                    Price = 214.24m,
                    Brand = "BYBLIGHT"
                },
                new Product
                    {
                        Id = 3,
                        Name = "Modern Standing/sitting desk",
                        Description = "Rising and Lowering wooden desk",
                        Price = 319.49m,
                        Brand = "FEZIBO Home Furniture"
                    },
                new Product
                {
                    Id = 4,
                    Name = "BYBLIGHT Lanita",
                    Description = "L-Shaped Brown Engineered wood 4-drawer computer desk",
                    Price = 559.99m,
                    Brand = "BYBLIGHT"
                },
                new Product
                {
                    Id = 5,
                    Name = "SILKYDRY Small Corner Desk",
                    Description = "Space-Saving corner workstation with storage shelves",
                    Price = 119.99m,
                    Brand = "SILKYDRY"
                });
        }
    }
}
