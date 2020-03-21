using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Domains.Abstract;

namespace Domains
{
    public class User : IDomain<int>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Данный прием позволяет использовать EF Core почти как EF6 при работе с many-to-many
        /// </summary>
        [NotMapped]
        public IEnumerable<Role> Roles
        {
            get => UserRoles.Select(x => x.Role);
            set => UserRoles = value.Select(x => new UserRole
            {
                RoleId = x.Id
            }).ToList();
        }
    }
}