using System.ComponentModel.DataAnnotations;

namespace CH02.Models
{
    public class Page2Calc
    {
        [Required(ErrorMessage = "Please enter a valid cost.")]
        [Range(1, 10000, ErrorMessage = "Please enter a valid cost.")]
        public decimal mealTotal { get; set; }
        public decimal tip15 => mealTotal * 0.15m;
        public decimal tip20 => mealTotal * 0.20m;
        public decimal tip25 => mealTotal * 0.25m;
        public decimal TotalAmount(decimal amount)
        {
            return mealTotal + amount;
        }
    }
}
