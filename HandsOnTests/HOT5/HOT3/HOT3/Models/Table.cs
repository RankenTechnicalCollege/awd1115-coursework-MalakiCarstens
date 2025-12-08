using System.ComponentModel.DataAnnotations;

namespace HOT3.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }
        public string? ImageFileName { get; set; }
        public string Slug(string name)
        {
            return Name?.ToLower().Replace(" ", "-");
        }
    }
}
