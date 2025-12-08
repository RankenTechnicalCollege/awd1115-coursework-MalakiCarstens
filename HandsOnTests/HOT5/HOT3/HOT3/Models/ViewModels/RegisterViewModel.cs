using System.ComponentModel.DataAnnotations;

namespace HOT3.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm passwords match")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string ConfirmPassword
        {
            get; set;

        }
    }
}
