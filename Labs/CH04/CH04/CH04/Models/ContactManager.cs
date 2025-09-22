using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CH04.Models
{
    public class ContactManager
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string? FirstName {  get; set; }
        [Required(ErrorMessage = "Please enter Last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        public string? PhoneNum { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string? Email { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Range(1,6)]
        public int CategoryId { get; set; }
        public DateTime Added { get; set; }
        public string? Slug => $"{FirstName?.ToLower()} {LastName?.ToLower()}".Replace(" ", "-");


    }
}
