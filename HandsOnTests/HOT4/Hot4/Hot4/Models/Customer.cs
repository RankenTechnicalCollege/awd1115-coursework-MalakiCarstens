using System.ComponentModel.DataAnnotations;

namespace Hot4.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, ErrorMessage = "Username must be at most 100 characters.")]
        public string Username { get; set; } 

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
