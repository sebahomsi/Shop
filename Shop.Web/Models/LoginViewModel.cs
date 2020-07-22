using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Minimun 6 characters.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
