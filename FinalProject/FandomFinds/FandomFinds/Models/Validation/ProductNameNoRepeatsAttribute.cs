using System.ComponentModel.DataAnnotations;

namespace FandomFinds.Models.Validation
{
    public class ProductNameNoRepeatsAttribute : ValidationAttribute

    {
        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            var _context = (ShopContext)ctx.GetService(typeof(ShopContext));
            string productName = value as string;


            bool exists = _context.Products.Any(p => p.Name == productName);

            if (exists)
            {
                return new ValidationResult("A product with this name already exists.");
            }

            return ValidationResult.Success;

        }
    }
}
