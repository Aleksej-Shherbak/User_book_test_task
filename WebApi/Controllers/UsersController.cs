using System.Threading.Tasks;
using AutoMapper;
using Domains;
using DTO;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repos.Abstract;
using Services.Abstract;
using WebApi.Filters;
using WebApi.Requests;
using WebApi.Responses;
using X.PagedList;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<PagedListResponse<UserResponse>> Index(int page = 1, int pageSize = 10)
        {
            var res = await _userRepository.All
                .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .ToPagedListAsync(page, pageSize);

            var response =  _mapper.Map<IPagedList<User>, IPagedList<UserResponse>>(res);
            
            return new PagedListResponse<UserResponse>(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<HttpResponse>> Create(UserRequest request)
        {
            var userDto = _mapper.Map<UserRequest, UserDto>(request);

            try
            {
                await _userService.Create(userDto);
                return new HttpResponse("Done.");
            }
            catch (EntityNotExistsException e)
            {
                ModelState.TryAddModelError(EntityNotExistsException.ModelStateKeyText, e.Message);
                return NotFound(ModelState);
            }
        }

        [HttpPatch("[action]/{id}")]
        [UserExistsFilter]
        public async Task<ActionResult<HttpResponse>> Edit(int id, UserRequest request)
        {
            var userDto = _mapper.Map<UserRequest, UserDto>(request);
            userDto.Id = id;

            try
            {
                await _userService.Edit(userDto);

                return new HttpResponse("Done");
            }
            catch (EntityNotExistsException e)
            {
                ModelState.TryAddModelError(EntityNotExistsException.ModelStateKeyText, e.Message);
                return NotFound(ModelState);
            }
        }

        [HttpDelete("[action]/{id}")]
        [UserExistsFilter]
        public async Task<ActionResult<HttpResponse>> Delete(int id)
        {
            await _userRepository.DeleteAsync(id);

            return new HttpResponse("Done.");
        }
    }
}