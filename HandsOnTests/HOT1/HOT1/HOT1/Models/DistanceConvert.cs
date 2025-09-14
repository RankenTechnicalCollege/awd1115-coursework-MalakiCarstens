using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HOT1.Models
{
    public class DistanceConvert
    {
        [Required(ErrorMessage = "Please enter valid inches.")]
        [Range(1,1000,ErrorMessage = "Please enter valid inches.")]
        public int Inches {  get; set; }

        public double Centimeters => Inches * 2.54;
        
    }
}
