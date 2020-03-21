using System.Threading.Tasks;
using AutoMapper;
using Domains;
using DTO;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Repos.Abstract;
using Services.Abstract;
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
        public async Task<PagedListResponse<User>> Index(int page = 1, int pageSize = 10)
        {
            var res =  await _userRepository.All.ToPagedListAsync(page, pageSize);

            return new PagedListResponse<User>(res);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserResponse>> Create(UserRequest request)
        {
            var userDto = _mapper.Map<UserRequest, UserDto>(request);

            try
            {
                var user = await _userService.Create(userDto);
                var response = _mapper.Map<User, UserResponse>(user);

                return response;
            }
            catch (EntityNotExistsException e)
            {
                ModelState.TryAddModelError(EntityNotExistsException.ModelStateKeyText, e.Message);
                return NotFound(ModelState);
            }
        }
        
        [HttpPatch("[action]/{id}")]
        public async Task<ActionResult<UserResponse>> Edit(int id, UserRequest request)
        {
            var userDto = _mapper.Map<UserRequest, UserDto>(request);
            userDto.Id = id;

            try
            {
                var user = await _userService.Create(userDto);
                var response = _mapper.Map<User, UserResponse>(user);

                return response;
            }
            catch (EntityNotExistsException e)
            {
                ModelState.TryAddModelError(EntityNotExistsException.ModelStateKeyText, e.Message);
                return NotFound(ModelState);
            }
        }
        
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<HttpResponse>> Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
            
            return new HttpResponse("Done.");
        }
        
    }
}