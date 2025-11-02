using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hot4.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Start time is required.")]
        [Display(Name = "Start Date/Time")]
        public DateTime StartDateTime { get; set; }


        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
     


        
        public Customer? Customer { get; set; }
    }
}

