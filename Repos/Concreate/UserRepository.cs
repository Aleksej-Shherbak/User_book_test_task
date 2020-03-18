using Domains;
using EntityFramework;
using Repos.Abstract;

namespace Repos.Concreate
{
    public class UserRepository: BaseRepository<User, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}