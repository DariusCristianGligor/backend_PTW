using Application;
using Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this._categoryRepository = categoryRepository;
        }
        [HttpGet("get")]
        public IActionResult Index()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpPost("post")]
        public IActionResult Create(Category category)
        {
            _categoryRepository.Create(category);
            return Ok("I did it!!!!!");
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Guid category)
        {
            _categoryRepository.Delete(category);
            return Ok("I removed it!!");
        }
    }
}
