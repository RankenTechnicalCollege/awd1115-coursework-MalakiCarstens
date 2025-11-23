using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace FandomFinds.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [ValidateNever]
        public Brand? Brand { get; set; }
        [ValidateNever]
        public int BrandId { get; set; }    
        public string? ImagePath { get; set; }
        public int Stock { get; set; }
    
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }


        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }
      
     
        public string Slug(string name)
        {
            return Name?.ToLower().Replace(" ", "-");
        }

    }
}
