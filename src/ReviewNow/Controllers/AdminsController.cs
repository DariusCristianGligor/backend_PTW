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
    public class AdminsController : ControllerBase
    {
        private readonly ILogger<AdminsController> logger;
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AdminsController(ILogger<AdminsController> logger, IAdminRepository adminRepository, IMapper mapper)
        {
            this.logger = logger;
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_adminRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminDto adminDto)
        {
            Admin AdminToAdd=_mapper.Map<Admin>(adminDto);
            Admin admin =await  _adminRepository.AddAsync(AdminToAdd);
            AdminExpDto adminExpDto = _mapper.Map<AdminExpDto>(admin);
            return Created("~", adminExpDto);
            //ok
        }

        [HttpDelete("{adminId}")]
        public  IActionResult Delete(Guid adminId)
    {
        if (_adminRepository.Find(adminId) == false) return NotFound();
         _adminRepository.Delete(adminId);
        return NoContent(); ;
        //204
    }
}
}
