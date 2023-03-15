using System.ComponentModel.DataAnnotations;

namespace Registration_Form.Models
{
    public class Person
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string? Gender { get; set; }
        public bool? SubscribeMe { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Country { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
