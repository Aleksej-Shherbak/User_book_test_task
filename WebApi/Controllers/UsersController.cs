using System;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Repos.Abstract;
using WebApi.Identity;
using WebApi.Requests;
using WebApi.Responses;
using WebApi.Responses.Abstract;
using X.PagedList;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedList<User>>> All(int page = 1, int pageSize = 10)
        {
            var usersPagedList = await _userRepository.AllAsPaged(page, pageSize);
            return usersPagedList;
        }

        [HttpPost("[action]")]
        [Authorize(Roles = RolesHelper.Admin)]
        public async Task<ActionResult<IInformationResponse>> Create(UserRequest request)
        {
            throw new  NotImplementedException();
        }
        
        [HttpPatch("[action]/{id}")]
        [Authorize(Roles = RolesHelper.Admin)]
        public async Task<ActionResult<IInformationResponse>> Edit(int id, UserRequest request)
        {
            throw new  NotImplementedException();
            
        }
        
        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = RolesHelper.Admin)]
        public async Task<ActionResult<IInformationResponse>> Delete(int id, UserRequest request)
        {
            throw new  NotImplementedException();
            
        }
        
    }
}