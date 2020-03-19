using AutoMapper;
using Domains;
using WebApi.Responses;

namespace WebApi.Automapper.Profiles
{
    public class RoleToRoleResponseProfile : Profile
    {
        public RoleToRoleResponseProfile()
        {
            CreateMap<Role, RoleResponse>();
        }
    }
}