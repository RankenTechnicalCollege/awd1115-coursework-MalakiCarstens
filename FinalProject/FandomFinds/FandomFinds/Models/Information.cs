using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FandomFinds.Models
{
    public class Information
    {
        public int InformationId { get; set; }
        public string Name { get; set; }
        public string ProductionStandards { get; set; }
        public string SafetyInformation { get; set; }
        [ValidateNever]
        public ICollection<ProductInformation> ProductInformation { get; set; }
    }
}