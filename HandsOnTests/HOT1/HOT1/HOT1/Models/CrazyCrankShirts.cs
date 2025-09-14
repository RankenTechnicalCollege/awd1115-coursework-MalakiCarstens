using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;


namespace HOT1.Models
{
    public class CrazyCrankShirts
    {
        [Required(ErrorMessage = "Please enter a quantity.")]
        [Range(1,50,ErrorMessage = "Please enter a quantity between 1 and 50.")]
        public decimal Quantity { get; set; }
        public string? Discount { get; set; }
        public decimal Tax { get; set; } = 0.08m;
        public decimal ShirtPrice { get; set; } = 15.00m;
        public decimal CalculateSubTotal()
        {
            decimal subtotal = Quantity * ShirtPrice;
            if (Discount == "6175" || Discount == "1390" || Discount == "BB88")
            {
                if (Discount == "6175")
                {
                    subtotal *= 0.70m;
                }
                else if (Discount == "1390")
                {
                    subtotal *= 0.80m;
                }
                else if (Discount == "BB88")
                {
                    subtotal *= 0.90m;
                }

            }
            return subtotal;
        }
        public decimal CalculateTotal()
        {
            decimal subtotal = CalculateSubTotal();
            decimal taxAmount = CalculateTax();
            decimal total = subtotal + taxAmount;
            return total;
        }
        public decimal CalculateTax()
        {
            decimal subtotal = CalculateSubTotal();
            decimal taxAmount = subtotal * Tax;
            return taxAmount;
        }
    }
}
