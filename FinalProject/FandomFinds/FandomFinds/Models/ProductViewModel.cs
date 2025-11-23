

namespace FandomFinds.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
       public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductReview> Reviews { get; set; }
    }
}
