using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using ReviewNow.ExportDtoClases;
using System;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]int page,[FromQuery]int pageSize)
        {
            return Ok(_categoryRepository.GetAll(page,pageSize));
        }
        [HttpGet("all")]
        public IActionResult Index()
        {
            return Ok(_categoryRepository.GetAll());
        }
        [HttpGet("numberOfCategory")]
        public IActionResult Get()
        {
            return Ok(_categoryRepository.GetNumberOfCategory());
        }

        [HttpGet("aplace/{placeId}")]
        public IActionResult Get(Guid placeId)
        {
            return Ok(_categoryRepository.GetAllByPlaceID(placeId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryDto categoryDto)
        {

            Category categoryToAdd = _mapper.Map<Category>(categoryDto);
            EntityEntry<Category> category = await _categoryRepository.CreateAsync(categoryToAdd);
            CategoryExportDto categoryExpDto = _mapper.Map<CategoryExportDto>(category);
            return Created($"~", categoryExpDto);
        }

        [HttpDelete("{categoryId}")]
        public IActionResult Delete(Guid categoryId)
        {
            if (_categoryRepository.Find(categoryId) == false)
                return NotFound();
            _categoryRepository.Delete(categoryId);
            return NoContent();
        }
    }
}
