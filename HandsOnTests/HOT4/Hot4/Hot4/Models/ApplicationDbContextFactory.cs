using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Hot4.Models
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Start from current directory
            var directory = Directory.GetCurrentDirectory();

            // Walk up until we find appsettings.json
            while (!File.Exists(Path.Combine(directory, "appsettings.json")))
            {
                var parent = Directory.GetParent(directory);
                if (parent == null)
                {
                    throw new FileNotFoundException("Could not find appsettings.json");
                }
                directory = parent.FullName;
            }

            // Load configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

