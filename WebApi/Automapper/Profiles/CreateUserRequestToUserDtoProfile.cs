using AutoMapper;
using Domains;
using DTO;
using WebApi.Requests;

namespace WebApi.Automapper.Profiles
{
    public class CreateUserRequestToUserDtoProfile : Profile
    {
        public CreateUserRequestToUserDtoProfile()
        {
            CreateMap<CreateUserRequest, UserDto>();
        }
    }
}