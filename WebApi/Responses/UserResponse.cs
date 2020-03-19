using System.Collections.Generic;

namespace WebApi.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<RoleResponse> Roles { get; set; }
    }
}