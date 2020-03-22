using AutoMapper;
using DTO;
using WebApi.Requests;

namespace WebApi.Automapper.Profiles
{
    public class UpdateUserRequestToUserDtoProfile: Profile
    {
        public UpdateUserRequestToUserDtoProfile()
        {
            CreateMap<EditUserRequest, UserDto>();
        }
    }
}