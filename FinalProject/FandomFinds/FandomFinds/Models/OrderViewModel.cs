namespace FandomFinds.Models
{
    public class OrderViewModel
    {
        public List<OrderItemViewModel> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
