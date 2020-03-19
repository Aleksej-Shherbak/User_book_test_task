using AutoMapper;
using Domains;
using WebApi.Responses;

namespace WebApi.Automapper.Profiles
{
    public class UserToUserResponseProfile: Profile
    {
        public UserToUserResponseProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}