using System.ComponentModel.DataAnnotations;

namespace DeepLearn.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get;set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and conf. password do not match.")]
        public string ConfirmPassword { get; set;}
    }

}
