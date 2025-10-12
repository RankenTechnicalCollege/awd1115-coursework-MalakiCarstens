using Microsoft.EntityFrameworkCore;


namespace FandomFinds.Models

{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().HasData(
                     new Brand { Id = 1, Name = "Nintendo" },
                     new Brand { Id = 2, Name = "S.H Figuarts" },
                     new Brand { Id = 3, Name = "Funko" }
          );

            modelBuilder.Entity<ProductReview>().HasData(
              new ProductReview { Id = 1, ProductId = 1, ReviewerName = "Thomas", ReviewText = "Great pack, got a super rare card too! It's my form of gambling. Lol.", Rating = 5 },
                 new ProductReview { Id = 2, ProductId = 2, ReviewerName = "Peter", ReviewText = "Amazing figure quality! It articulates so well.", Rating = 4 },
                  new ProductReview { Id = 3, ProductId = 4, ReviewerName = "Amy", ReviewText = "Cute Funko Pop. I have a huge collection and I'm so excited to add this to the collection!", Rating = 5 }
                         );




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
