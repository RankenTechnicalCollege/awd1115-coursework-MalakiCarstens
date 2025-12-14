namespace FandomFinds.Models.ViewModels
{
    public class OrderViewModel
    {
        public List<OrderItemViewModel> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
