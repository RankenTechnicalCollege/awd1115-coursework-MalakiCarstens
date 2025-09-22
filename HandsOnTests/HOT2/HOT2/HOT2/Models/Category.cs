using System.ComponentModel.DataAnnotations;

namespace HOT2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Must select category.")]
        public string? CategoryName { get; set; }
        public Product? Product { get; set; }
    }
}
