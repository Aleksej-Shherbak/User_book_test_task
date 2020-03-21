using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Requests
{
    public class UserRequest
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Логин является обязательным полем")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Email является обязательным полем")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Пароль является обязательным полем")]
        public string Password { get; set; }
        
        public List<int> RolesIds { get; set; }
    }
}