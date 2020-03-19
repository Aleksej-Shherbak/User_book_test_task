using System;
using System.Collections.Generic;

namespace DTO
{
    /// <summary>
    /// Данный класс служит для транспортировки данных между сервисом пользователей UserService
    /// и любым другим элементом системы, использующим его. 
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> RolesIds { get; set; }
    }
}