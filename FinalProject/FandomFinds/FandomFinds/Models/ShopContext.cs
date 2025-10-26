using Microsoft.EntityFrameworkCore;


namespace FandomFinds.Models

{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Order> Orders { get; set; }



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
                    Brand = "Nintendo",
                    ImagePath = "/images/destined-rival.jpg"


                },
                new Product
                {
                    Id = 2,
                    Name = "S.H Figuarts Spider-Man",
                    Description = "High end action figure. Highly articulated.",
                    Price = 65.99m,
                    Brand = "sh figuarts",
                    ImagePath = "/images/spiderman.jpg"
                },
                    new Product
                    {
                        Id = 3,
                        Name = "S.H Figuarts Broly",
                        Description = "High end action figure. Highly articulated.",
                        Price = 89.99m,
                        Brand = "sh figuarts",
                        ImagePath = "/images/broly.jpg"
                    },
                new Product
                {
                    Id = 4,
                    Name = "Metal Sonic Funko Pop",
                    Description = "Vinyl Collectable figure 6 inches in height",
                    Price = 12.99m,
                    Brand = "Funko",
                    ImagePath = "/images/metal-sonic-funko.jpg"
                },
                   new Product
                   {
                       Id = 5,
                       Name = "Pokemon figure- Mega Blaziken",
                       Description = "Collectable. Rare find",
                       Price = 109.99m,
                       Brand = "Tomy",
                          ImagePath = "/images/blaziken.jpg"
                   },
                      new Product
                      {
                          Id = 6,
                          Name = "Cat Mario",
                          Description = "5in Mario figure in cat suit. Includes a question box. Exclusive movie merch",
                          Price = 14.99m,
                          Brand = "jakks",
                            ImagePath = "/images/cat-mario.jpg"
                      },
                       new Product
                       {
                           Id = 7,
                           Name = "S.h. Figuarts Denji chainsaw man figure. Double pack",
                           Description = "High end action figure. Highly articulated. 2 pack. Reenact scenes from the manga with the high poseable figures",
                           Price = 149.99m,
                           Brand = "sh figuarts",
                            ImagePath = "/images/chainsawman.jpg"
                       },
                        new Product
                        {
                            Id = 8,
                            Name = "StarWars General Grevious figure",
                            Description = "High end action figure. Highly articulated. Includes lightsabers.",
                            Price = 89.99m,
                            Brand = "sh figuarts",
                             ImagePath = "/images/grevious.jpg"
                        },
                           new Product
                           {
                               Id = 9,
                               Name = "King Cold-Dragonball figure",
                               Description = "High end action figure. Highly articulated. Includes sword and cape. 12in figure.",
                               Price = 109.99m,
                               Brand = "sh figuarts",
                                ImagePath = "/images/king-cold.jpg"
                           },
                              new Product
                              {
                                  Id = 10,
                                  Name = "Mario Set 4 pack",
                                  Description = "4 characters all included in this special pack. Articulated. Detailed designs. Inspired by the movie! Perfect set for collectors",
                                  Price = 49.99m,
                                  Brand = "jakks",
                                   ImagePath = "/images/mario-set.jpg"
                              },
                                 new Product
                                 {
                                     Id = 11,
                                     Name = "Mario S.H. Figuarts",
                                     Description = "Very rare mario figure. Brand new. Sealed.",
                                     Price = 149.99m,
                                     Brand = "sh figuarts",
                                      ImagePath = "/images/mario-sh.jpg"
                                 },
                                    new Product
                                    {
                                        Id = 12,
                                        Name = "Metal Sonic figure",
                                        Description = "Hard to find. Articulated. Very detailed ",
                                        Price = 69.99m,
                                         Brand = "jakks",
                                          ImagePath = "/images/metal-sonic.jpg"
                                    },
                                       new Product
                                       {
                                           Id = 13,
                                           Name = "S.H Figuarts Miles Morales figure",
                                           Description = "High end action figure. Highly articulated. Includes many accessories. Realistic.",
                                           Price = 89.99m,
                                           Brand = "sh figuarts",
                                            ImagePath = "/images/miles.jpg"
                                       },
                                         new Product
                                         {
                                             Id = 14,
                                             Name = "Metal Sonic figure",
                                             Description = "Hard to find. Articulated. Very detailed ",
                                             Price = 69.99m,
                                             Brand = "jakks",
                                             ImagePath = "/images/metal-sonic.jpg"
                                         },
                                           new Product
                                           {
                                               Id = 15,
                                               Name = "Stranger Things Character set",
                                               Description = "Reenact classic scenes from highly popular show Stranger Things. Includes Demigorgan, Dustin and Will. ",
                                               Price = 29.99m,
                                               Brand = "Entertainment E",
                                               ImagePath = "/images/stranger-set.jpg"
                                           },
                                             new Product
                                             {
                                                 Id = 16,
                                                 Name = "Scarlet Spiderman",
                                                 Description = "Hard to find. Articulated. Very detailed ",
                                                 Price = 99.99m,
                                                 Brand = "S.H Figuarts",
                                                 ImagePath = "/images/scarletspider.jpg"
                                             },
                                               new Product
                                               {
                                                   Id = 17,
                                                   Name = "Eleven Stranger Things figure",
                                                   Description = "Hard to find. From season one of Strangers Things. Eleven in dress with shaved head.",
                                                   Price = 59.99m,
                                                   Brand = "Entertainment E",
                                                   ImagePath = "/images/stranger-11.jpg"
                                               },
                                                 new Product
                                                 {
                                                     Id = 18,
                                                     Name = "Chainsaw Man Power Figure",
                                                     Description = "Articulated. Very detailed. Accessories included. Collect them all!",
                                                     Price = 79.99m,
                                                     Brand = "S.H Figuarts",
                                                     ImagePath = "/images/power.jpg"
                                                 },
                                                   new Product
                                                   {
                                                       Id = 19,
                                                       Name = "Transformers Optimus Prime figure",
                                                       Description = "Collectable. In original packaging. Perfect condition. Perfect for the collector in you life.",
                                                       Price = 29.99m,
                                                       Brand = "Hasbro",
                                                       ImagePath = "/images/optimus-prime.jpg"
                                                   });
        }
    }
}
