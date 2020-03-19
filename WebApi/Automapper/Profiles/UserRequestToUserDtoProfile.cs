using AutoMapper;
using Domains;
using DTO;
using WebApi.Requests;

namespace WebApi.Automapper.Profiles
{
    public class UserRequestToUserDtoProfile : Profile
    {
        public UserRequestToUserDtoProfile()
        {
            CreateMap<UserRequest, UserDto>();
        }
    }
}