namespace CH04.Models
{
    public class Category
    {
        public List<ContactManager> contacts { get; set; } = new();
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
