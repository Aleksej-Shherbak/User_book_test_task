using Domains;
using EntityFramework;
using Repos.Abstract;

namespace Repos.Concreate
{
    public class RoleRepository: BaseRepository<Role, ApplicationDbContext>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}