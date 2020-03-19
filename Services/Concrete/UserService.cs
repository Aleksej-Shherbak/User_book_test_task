using System.Linq;
using System.Threading.Tasks;
using Domains;
using DTO;
using Repos.Abstract;
using Services.Abstract;
using System.Security.Cryptography;
using Infrastructure.Exceptions;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<User> Create(UserDto dto)
        {
            if (dto.RolesIds == null || !dto.RolesIds.Any())
            {
                return null;
            }

            var roles =
                await _roleRepository.All
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Where(x => dto.RolesIds.Contains(x.Id)).ToListAsync();

            if (roles.Count != dto.RolesIds.Count)
            {
                throw new EntityNotExistsException("В списке ролей есть несуществующие роли");
            }

            var user = new User
            {
                Login = dto.Login,
                Name = dto.Name,
                Password = Crypt.CreateMd5(dto.Password),
                Roles = roles
            };

            await _userRepository.SaveAsync(user);
            return user;
        }

        public async Task<User> Edit(UserDto dto)
        {
            var user = await _userRepository.All
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            var roles =
                await _roleRepository.All.Where(x => dto.RolesIds.Contains(x.Id)).ToListAsync();

            if (roles.Count != dto.RolesIds.Count)
            {
                throw new EntityNotExistsException("В списке ролей есть несуществующие роли");
            }

            user.Name = dto.Name;
            user.Password = Crypt.CreateMd5(dto.Password);
            user.Roles = roles;

            await _userRepository.SaveAsync(user);
            return user;
        }
    }
}