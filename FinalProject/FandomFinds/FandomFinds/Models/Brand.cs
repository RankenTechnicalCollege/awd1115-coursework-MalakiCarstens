namespace FandomFinds.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public string Slug(string name)
        {
            return Name?.ToLower().Replace(" ", "-");
        }
    }
}
