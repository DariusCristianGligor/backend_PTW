using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryRepository categoryRepository;
 

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            this.categoryRepository = categoryRepository;
           
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoryRepository.GetAll());
        }
    }
}
