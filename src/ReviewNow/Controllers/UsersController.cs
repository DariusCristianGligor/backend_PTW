using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReviewNow.ExportDtoClases;
using System;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]int page,[FromQuery]int pageSize)
        {
            return Ok(_userRepository.GetAll(page,pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserDto userDto)
        {
            User userToAdd = _mapper.Map<User>(userDto);
            EntityEntry<User> user = await _userRepository.AddAsync(userToAdd);
            UserExportDto userExpDto = _mapper.Map<UserExportDto>(user);
            return Created("~", userExpDto);
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
