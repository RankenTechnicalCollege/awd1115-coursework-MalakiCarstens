using FandomFinds.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace FandomFinds.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [ProductNameNoRepeats]
        public IEnumerable<Product> Products { get; set; }
       public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductReview> Reviews { get; set; }
    }
}
