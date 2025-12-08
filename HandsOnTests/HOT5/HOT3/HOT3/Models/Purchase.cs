namespace HOT3.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public Table? Table { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int TableId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
