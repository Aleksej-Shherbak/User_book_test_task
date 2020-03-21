using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repos.Abstract;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController: ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<RoleResponse>>> Index()
        {
            var roles = await _roleRepository.All.ToListAsync();
            var result = _mapper.Map<List<Role>, List<RoleResponse>>(roles);
            return result;
        }
    }
}