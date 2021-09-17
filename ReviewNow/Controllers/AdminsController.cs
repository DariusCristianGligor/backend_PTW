using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminsController: ControllerBase
    {
        private readonly ILogger<AdminsController> logger;
    private readonly IAdminRepository _adminRepository;

    public AdminsController(ILogger<AdminsController> logger, IAdminRepository adminRepository)
    {
        this.logger = logger;
        _adminRepository = adminRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_adminRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Create(Admin admin)
    {
            _adminRepository.Add(admin);
        return Ok("I did it!!!!!");
    }

    [HttpDelete]
    public IActionResult Delete(Guid adminId)
    {
        _adminRepository.Delete(adminId);
        return Ok("I removed it!!");
    }
}
}
