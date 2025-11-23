namespace FandomFinds.Models
{
    public class OrderItemViewModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }

        public string Name { get; set; }
    }
}
