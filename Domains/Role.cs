using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Domains.Abstract;

namespace Domains
{
    public class Role : IDomain<int>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Данный прием позволяет использовать EF Core почти как EF6 при работе с many-to-many
        /// </summary>
        [NotMapped]
        public IEnumerable<User> Users
        {
            get => UserRoles.Select(x => x.User);
            set => UserRoles = value.Select(x => new UserRole
            {
                UserId = x.Id
            }).ToList();
        }
    }
}