using AutoMapper;
using Domains;
using WebApi.Automapper.Convertors;
using WebApi.Responses;
using X.PagedList;

namespace WebApi.Automapper.Profiles
{
    public class UserPagedListToUserPagedListResponse: Profile 
    {
        public UserPagedListToUserPagedListResponse()
        {
            CreateMap<IPagedList<User>, IPagedList<UserResponse>>()
                .ConvertUsing<PagedListConverter<User, UserResponse>>();
        }
    }
}