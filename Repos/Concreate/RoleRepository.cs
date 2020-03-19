using Domains;
using EntityFramework;

namespace Repos.Concreate
{
    public class RoleRepository: BaseRepository<Role, ApplicationDbContext>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}