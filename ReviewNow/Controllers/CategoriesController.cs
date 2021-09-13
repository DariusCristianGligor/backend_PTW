using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryRepository.Create(category);
            return Ok("I did it!!!!!");
        }

        [HttpDelete]
        public IActionResult Delete(Guid category)
        {
            _categoryRepository.Delete(category);
            return Ok("I removed it!!");
        }
    }
}
