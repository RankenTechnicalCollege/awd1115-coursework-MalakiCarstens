using Microsoft.EntityFrameworkCore;

namespace CH06.Models
{
    public class FaqsContext : DbContext
    {
        public FaqsContext(DbContextOptions<FaqsContext> options) : base(options)
        {

        }
        public DbSet<FAQ> FAQs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "hist", Name = "History" });

            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "asp", Name = "ASP.NET Core" },
                new Topic { TopicId = "blz", Name = "Blazor" },
                new Topic { TopicId = "ef", Name = "Entity Framework"});
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FAQId = 1, Question = "What is ASP.NET Core?", Answer = "ASP.NET Core is a free and open-source web framework, and the next generation of ASP.NET, developed by Microsoft.", CategoryId = "gen", TopicId = "asp" },
                new FAQ { FAQId = 2, Question = "When was ASP.NET Core released?", Answer = "ASP.NET Core 1.0 was released on June 27, 2016.", CategoryId = "hist", TopicId = "asp" },
                new FAQ { FAQId = 3, Question = "What is Blazor?", Answer = "Blazor is a free open-source web framework that enables develpers to create interactive web user interfaces using C# and HTML.", CategoryId = "gen", TopicId = "blz" },
                new FAQ { FAQId = 4, Question = "When was Blazor released?", Answer = "Blazor was released on September 23, 2019.", CategoryId = "hist", TopicId = "blz" },
                new FAQ { FAQId = 5, Question = "What is Entity Framework?", Answer = "Entity Framework is an open-source ORM framework for .NET applications supported by Microsoft.", CategoryId = "hist", TopicId = "ef" }
                );
        }
    }
}
