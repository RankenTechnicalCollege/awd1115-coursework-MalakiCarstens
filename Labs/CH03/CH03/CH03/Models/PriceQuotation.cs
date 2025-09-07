using System.ComponentModel.DataAnnotations;

namespace CH03.Models
{
    public class PriceQuotation
    {
        [Required(ErrorMessage = "Please enter valid numbers.")]
        [Range(0.01, 1000, ErrorMessage = "Please enter a valid subtotal.")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter valid numbers.")]
        [Range(0.01, 1000, ErrorMessage = "Please enter a valid discount percent.")]
        public decimal DiscountPercent { get; set; }

        public decimal DiscountAmount()
        {
            return Subtotal * (DiscountPercent / 100);
        }
        public decimal Total()
        {
            return Subtotal - DiscountAmount();
        }
    }
}
