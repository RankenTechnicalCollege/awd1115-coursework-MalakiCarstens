using Microsoft.EntityFrameworkCore;

namespace HOT2.Models
{
    public class ProductContext : DbContext
    {

    
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithOne(c => c.Product).HasForeignKey<Product> (p => p.CategoryID);
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Components" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Accessories" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Tools" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Home Improvement" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Lighting" });




            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, ProductName = "AeroFlo ATB Wheels", ProductImage="", ProductDescShort = "", ProductDescLong = "", ProductPrice = 189.00m, ProductQty = 40, CategoryID = 1 },
            new Product { ProductId = 2, ProductName = "Clear Shade 85-T Glasses", ProductImage = "", ProductDescShort = "", ProductDescLong = "", ProductPrice = 45.00m, ProductQty = 14, CategoryID = 2 },
            new Product { ProductId = 3, ProductName = "Cosmic Elite Road Warrior Wheels", ProductImage = "", ProductDescShort = "", ProductDescLong = "", ProductPrice = 160.00m, ProductQty = 22, CategoryID = 3 },
            new Product { ProductId = 4, ProductName = "Cycle-Doc Pro Repair Stand", ProductImage = "", ProductDescShort = "", ProductDescLong = "", ProductPrice = 166.00m, ProductQty = 12, CategoryID = 4 },
            new Product { ProductId = 5, ProductName = "Dog Ear Aero-Flow Floor Pump", ProductImage = "", ProductDescShort = "", ProductDescLong = "", ProductPrice = 55.00m, ProductQty = 22, CategoryID = 5 });
        }
    }
}
