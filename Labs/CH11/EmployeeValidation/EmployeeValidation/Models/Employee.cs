using System.ComponentModel.DataAnnotations;

namespace EmployeeValidation.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
    }
}
