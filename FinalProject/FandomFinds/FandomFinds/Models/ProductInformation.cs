namespace FandomFinds.Models
{
    public class ProductInformation
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InformationId { get; set; }
        public Information Information { get; set; }
    }
}
