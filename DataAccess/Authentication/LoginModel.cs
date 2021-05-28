using System.ComponentModel.DataAnnotations;

namespace DataAccess.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "User password is required")]
        public string Password { get; set; }
    }
}
