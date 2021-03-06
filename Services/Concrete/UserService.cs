using System.Linq;
using System.Threading.Tasks;
using Domains;
using DTO;
using Infrastructure.Exceptions;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Repos.Abstract;
using Services.Abstract;

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
                Email = dto.Email,
                Name = dto.Name,
                Password = Crypt.CreateMd5(dto.Password),
                Roles = roles
            };

            await _userRepository.SaveAsync(user);
            return user;
        }

        public async Task<User> Edit(UserDto dto)
        {
            var roles =
                await _roleRepository.All
                    .Include(x => x.UserRoles).ThenInclude(x => x.User)
                    .Where(x => dto.RolesIds.Contains(x.Id)).ToListAsync();

            if (roles.Count != dto.RolesIds.Count)
            {
                throw new EntityNotExistsException("В списке ролей есть несуществующие роли");
            }

            var user = await _userRepository.All
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            
            user.Name = dto.Name;
            user.Email = dto.Email;

            // яесли пароль не пустой, то пользователь хочет его обновить.
            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.Password = Crypt.CreateMd5(dto.Password);
            }

            user.Roles = roles;

            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}