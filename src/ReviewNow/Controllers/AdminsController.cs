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
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AdminsController(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        public AdminsController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_adminRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminDto adminDto)
        {
            Admin AdminToAdd = _mapper.Map<Admin>(adminDto);
            EntityEntry<Admin> admin = await _adminRepository.AddAsync(AdminToAdd);
            AdminExportDto adminExpDto = _mapper.Map<AdminExportDto>(admin);
            return Created("~", adminExpDto);
            //ok
        }

        [HttpDelete("{adminId}")]
        public IActionResult Delete(Guid adminId)
        {
            if (_adminRepository.Find(adminId) == false)
                return NotFound();
            _adminRepository.Delete(adminId);
            return NoContent(); ;
            //204
        }
    }
}
