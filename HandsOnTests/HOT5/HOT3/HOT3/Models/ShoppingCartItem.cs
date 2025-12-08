namespace HOT3.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Table? Table { get; set; }
        public int Quantity { get; set; }
    }
}
