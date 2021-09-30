using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewNow.ExportDtoClases;
using System;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, IUsersRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserDto userDto)
        {
            User userToAdd = _mapper.Map<User>(userDto);
            User user=await _userRepository.AddAsync(userToAdd);
            UserExpDto userExpDto = _mapper.Map<UserExpDto>(user);
            return Created("~",userExpDto);
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(Guid userId)
        {
            if (_userRepository.Find(userId) == false)
                return NotFound();

            _userRepository.Delete(userId);

            return NoContent();
        }
    }
}
