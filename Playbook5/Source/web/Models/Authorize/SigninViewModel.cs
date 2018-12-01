using System.ComponentModel.DataAnnotations;

namespace web.Models.Authorize
{
    public class SigninViewModel
    {
        public SigninViewModel() { }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}