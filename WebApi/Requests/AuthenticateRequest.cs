using System.ComponentModel.DataAnnotations;

namespace WebApi.Requests
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}