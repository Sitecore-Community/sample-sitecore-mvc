using System.ComponentModel.DataAnnotations;

namespace MVC.Data.Models
{
    public class CustomerDetails
    {
        [Required]
        [Range(0, 200, ErrorMessage = "Please enter valid age")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please enter Male or Female", MinimumLength = 3)]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please enter valid location", MinimumLength = 3)]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }
    }
}
