using System.ComponentModel.DataAnnotations;

namespace WebApi.Requests
{
    public class UserRequest
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}