namespace FandomFinds.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug(string name)
        {
            return Name?.ToLower().Replace(" ", "-");
        }
    }
}
