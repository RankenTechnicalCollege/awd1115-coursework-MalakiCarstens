using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FandomFinds.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;
        public decimal TotalAmount { get; set; }

        public string? OrderName { get; set; }
        [ValidateNever] 
        public ApplicationUser? User { get; set; }
         public string ApplicationUserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public string Slug(string name)
        {
            return OrderName?.ToLower().Replace(" ", "-");
        }

    }
}
