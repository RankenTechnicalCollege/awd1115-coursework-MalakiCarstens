namespace HOT3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Slug(string name)
        {
            return Name?.ToLower().Replace(" ", "-");
        }
    }
}
