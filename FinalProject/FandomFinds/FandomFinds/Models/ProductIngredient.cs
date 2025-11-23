namespace FandomFinds.Models
{
    public class ProductIngredient
    {
        public int ProdductId { get; set; }
        public Product Product { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
