using System.Threading.Tasks;
using Domains;
using DTO;

namespace Services.Abstract
{
    public interface IUserService
    {
        Task<User> Create(UserDto dto);
        Task<User> Edit(UserDto dto);
    }
}