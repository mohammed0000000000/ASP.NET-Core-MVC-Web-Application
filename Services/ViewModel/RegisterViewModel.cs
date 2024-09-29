using System.ComponentModel.DataAnnotations;

namespace TechWebApplication.Services.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "InValid Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address2 { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9 ]{3,10}$", ErrorMessage = "InValid PostCode")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        [RegularExpression("^\\+?[0-9\\s\\-\\(\\)]{7,15}$", ErrorMessage ="InValid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public bool AcceptUserAgreement{ get; set; }    
        public string RegistrationInValid { get; set; } = "true";
    }
}
