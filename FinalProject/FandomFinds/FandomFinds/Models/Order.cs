using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FandomFinds.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;
        public string TotalAmount { get; set; }
        [ValidateNever] 
        public IdentityUser User { get; set; }

        public string IdentityUserId { get; set; }
    }
}
