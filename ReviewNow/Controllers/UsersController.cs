using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUsersRepostory _userRepository;

        public UsersController(ILogger<UsersController> logger, IUsersRepostory userRepository)
        {
            this.logger = logger;
            this._userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userRepository.Add(user);
            return Ok("I did it!!!!!");
        }

        [HttpDelete]
        public IActionResult Delete(Guid userId)
        {
            _userRepository.Delete(userId);
            return Ok("I removed it!!");
        }
    }
}
