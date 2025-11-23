using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace FandomFinds.Models

{
    public class ShopContext : IdentityDbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //builder.Entity<ProductIngredient>().HasKey(pi => new { pi.ProductId, pi.IngredientId });
            //builder.Entity<ProductIngredient>().HasOne(pi => pi.Product).WithMany(p => p.ProductIngredients).HasForeignKey(pi => pi.ProductId);
            //builder.Entity<ProductIngredient>().HasOne(pi => pi.Ingredient).WithMany(i => i.ProductIngredients).HasForeignKey(pi => pi.IngredientId);


            modelBuilder.Entity<Brand>().HasData(
                     new Brand { BrandId = 1, Name = "Nintendo" },
                     new Brand { BrandId = 2, Name = "S.H Figuarts" },
                     new Brand { BrandId = 3, Name = "Funko" },
                     new Brand { BrandId = 4, Name = "Hasbro"},
                     new Brand { BrandId = 5, Name = "Tomy"},
                     new Brand { BrandId = 6, Name = "Jakks"}
          );

            modelBuilder.Entity<ProductReview>().HasData(
              new ProductReview { Id = 1, ProductId = 1, ReviewerName = "Thomas", ReviewText = "Great pack, got a super rare card too! It's my form of gambling. Lol.", Rating = 5 },
                 new ProductReview { Id = 2, ProductId = 2, ReviewerName = "Peter", ReviewText = "Amazing figure quality! It articulates so well.", Rating = 4 },
                  new ProductReview { Id = 3, ProductId = 4, ReviewerName = "Amy", ReviewText = "Cute Funko Pop. I have a huge collection and I'm so excited to add this to the collection!", Rating = 5 }
          );




            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Destined Rival TCG Pokemon",
                    Description = "Booster pack with 10 cards and a code card for online game. Each pack is random.",
                    Price = 5.99m,
                    BrandId = 1,
                    ImagePath = "/images/destined-rival.jpg",
                    ImageUrl = "/images/destined-rival.jpg"


                },
                new Product
                {
                    ProductId = 2,
                    Name = "S.H Figuarts Spider-Man",
                    Description = "High end action figure. Highly articulated.",
                    Price = 65.99m,
                    BrandId = 2,
                    ImagePath = "/images/spiderman.jpg",
                    ImageUrl = "/images/spiderman.jpg"
                },
                    new Product
                    {
                        ProductId = 3,
                        Name = "S.H Figuarts Broly",
                        Description = "High end action figure. Highly articulated.",
                        Price = 89.99m,
                        BrandId = 2,
                        ImagePath = "/images/broly.jpg",
                        ImageUrl = "/images/broly.jpg"
                    },
                new Product
                {
                    ProductId = 4,
                    Name = "Metal Sonic Funko Pop",
                    Description = "Vinyl Collectable figure 6 inches in height",
                    Price = 12.99m,
                    BrandId = 3,
                    ImagePath = "/images/metal-sonic-funko.jpg",
                    ImageUrl = "/images/metal-sonic-funko.jpg"
                },
                   new Product
                   {
                       ProductId = 5,
                       Name = "Pokemon figure- Mega Blaziken",
                       Description = "Collectable. Rare find",
                       Price = 109.99m,
                       BrandId = 5,
                       ImagePath = "/images/blaziken.jpg",
                       ImageUrl = "/images/blaziken.jpg"
                   },
                      new Product
                      {
                          ProductId = 6,
                          Name = "Cat Mario",
                          Description = "5in Mario figure in cat suit. Includes a question box. Exclusive movie merch",
                          Price = 14.99m,
                          BrandId = 6,
                          ImagePath = "/images/cat-mario.jpg",
                          ImageUrl = "/images/cat-mario.jpg"
                      },
                       new Product
                       {
                           ProductId = 7,
                           Name = "S.h. Figuarts Denji chainsaw man figure. Double pack",
                           Description = "High end action figure. Highly articulated. 2 pack. Reenact scenes from the manga with the high poseable figures",
                           Price = 149.99m,
                           BrandId = 2,
                           ImagePath = "/images/chainsawman.jpg",
                           ImageUrl = "/images/chainsawman.jpg"
                       },
                        new Product
                        {
                            ProductId = 8,
                            Name = "StarWars General Grevious figure",
                            Description = "High end action figure. Highly articulated. Includes lightsabers.",
                            Price = 89.99m,
                            BrandId = 2,
                            ImagePath = "/images/grevious.jpg",
                            ImageUrl = "/images/grevious.jpg"
                        },
                           new Product
                           {
                               ProductId = 9,
                               Name = "King Cold-Dragonball figure",
                               Description = "High end action figure. Highly articulated. Includes sword and cape. 12in figure.",
                               Price = 109.99m,
                               BrandId = 2,
                               ImagePath = "/images/king-cold.jpg",
                               ImageUrl = "/images/king-cold.jpg"
                           },
                              new Product
                              {
                                  ProductId = 10,
                                  Name = "Mario Set 4 pack",
                                  Description = "4 characters all included in this special pack. Articulated. Detailed designs. Inspired by the movie! Perfect set for collectors",
                                  Price = 49.99m,
                                  BrandId = 6,
                                  ImagePath = "/images/mario-set.jpg",
                                  ImageUrl = "/images/mario-set.jpg"
                              },
                                 new Product
                                 {
                                     ProductId = 11,
                                     Name = "Mario S.H. Figuarts",
                                     Description = "Very rare mario figure. Brand new. Sealed.",
                                     Price = 149.99m,
                                     BrandId = 2,
                                     ImagePath = "/images/mario-sh.jpg",
                                     ImageUrl = "/images/mario-sh.jpg"
                                 },
                                    new Product
                                    {
                                        ProductId = 12,
                                        Name = "Metal Sonic figure",
                                        Description = "Hard to find. Articulated. Very detailed ",
                                        Price = 69.99m,
                                        BrandId = 6,
                                        ImagePath = "/images/metal-sonic.jpg",
                                        ImageUrl = "/images/metal-sonic.jpg"
                                    },
                                       new Product
                                       {
                                           ProductId = 13,
                                           Name = "S.H Figuarts Miles Morales figure",
                                           Description = "High end action figure. Highly articulated. Includes many accessories. Realistic.",
                                           Price = 89.99m,
                                           BrandId = 2,
                                           ImagePath = "/images/miles.jpg",
                                           ImageUrl = "/images/miles.jpg"
                                       },
                                         new Product
                                         {
                                             ProductId = 14,
                                             Name = "Metal Sonic figure",
                                             Description = "Hard to find. Articulated. Very detailed ",
                                             Price = 69.99m,
                                             BrandId = 6,
                                             ImagePath = "/images/metal-sonic.jpg",
                                             ImageUrl = "/images/metal-sonic.jpg"
                                         },
                                           new Product
                                           {
                                               ProductId = 15,
                                               Name = "Stranger Things Character set",
                                               Description = "Reenact classic scenes from highly popular show Stranger Things. Includes Demigorgan, Dustin and Will. ",
                                               Price = 29.99m,
                                               BrandId = 4,
                                               ImagePath = "/images/stranger-set.jpg",
                                               ImageUrl = "/images/stranger-set.jpg"
                                           },
                                             new Product
                                             {
                                                 ProductId = 16,
                                                 Name = "Scarlet Spiderman",
                                                 Description = "Hard to find. Articulated. Very detailed ",
                                                 Price = 99.99m,
                                                 BrandId = 2,
                                                 ImagePath = "/images/scarletspider.jpg",
                                                 ImageUrl = "/images/scarletspider.jpg"
                                             },
                                               new Product
                                               {
                                                   ProductId = 17,
                                                   Name = "Eleven Stranger Things figure",
                                                   Description = "Hard to find. From season one of Strangers Things. Eleven in dress with shaved head.",
                                                   Price = 59.99m,
                                                   BrandId = 4,
                                                   ImagePath = "/images/stranger-11.jpg",
                                                   ImageUrl = "/images/stranger-11.jpg"
                                               },
                                                 new Product
                                                 {
                                                     ProductId = 18,
                                                     Name = "Chainsaw Man Power Figure",
                                                     Description = "Articulated. Very detailed. Accessories included. Collect them all!",
                                                     Price = 79.99m,
                                                     BrandId = 2,
                                                     ImagePath = "/images/power.jpg",
                                                     ImageUrl = "/images/power.jpg"
                                                 },
                                                   new Product
                                                   {
                                                       ProductId = 19,
                                                       Name = "Transformers Optimus Prime figure",
                                                       Description = "Collectable. In original packaging. Perfect condition. Perfect for the collector in you life.",
                                                       Price = 29.99m,
                                                       BrandId = 4,
                                                       ImagePath = "/images/optimus-prime.jpg",
                                                       ImageUrl = "/images/optimus-prime.jpg"
                                                   });


        }
    }
}
