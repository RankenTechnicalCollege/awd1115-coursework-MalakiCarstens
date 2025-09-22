using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HOT2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? ProductName { get; set; }
        public string? ProductDescShort { get; set; }
        public string? ProductDescLong { get; set; }
        [Required (ErrorMessage = "Image is required")]
        public string? ProductImage { get; set; }
        [Required(ErrorMessage = "Price must be between 1-10000")]
        [Range(1,10000)]
        public decimal? ProductPrice { get; set; }
        [Required(ErrorMessage = "Quantity must be between 1-1000")]
        [Range(1,1000)]
        public int? ProductQty { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public string? Slug => $"{ProductName?.Replace(' ', '-')}";

    } 

}
