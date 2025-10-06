using Microsoft.EntityFrameworkCore;


namespace FandomFinds.Models

{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Destined Rival TCG Pokemon",
                    Description = "Booster pack with 10 cards and a code card for online game. Each pack is random.",
                    Price = 5.99m,
                    Brand = "Nintendo"


                },
                new Product
                {
                    Id = 2,
                    Name = "S.H Figuarts Spider-Man",
                    Description = "High end action figure. Highly articulated.",
                    Price = 65.99m,
                    Brand = "sh figuarts"
                },
                    new Product
                    {
                        Id = 3,
                        Name = "S.H Figuarts Broly",
                        Description = "High end action figure. Highly articulated.",
                        Price = 89.99m,
                        Brand = "sh figuarts"
                    },
                new Product
                {
                    Id = 4,
                    Name = "Metal Sonic Funko Pop",
                    Description = "Vinyl Collectable figure 6 inches in height",
                    Price = 12.99m,
                    Brand = "Funko"
                });
        }
    }
}
