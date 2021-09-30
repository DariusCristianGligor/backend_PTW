using Application;
using Domain;
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
    public class CitiesController: ControllerBase
    {
        private readonly ILogger<CitiesController> logger;
        private readonly ICityRepository cityRepository;

        public CitiesController(ILogger<CitiesController> logger,ICityRepository cityRepository)
        {
            this.logger = logger;
            this.cityRepository = cityRepository;
        }
        
        [HttpGet("{countryId}")]
        public IActionResult Get(Guid countryId)
        {
            logger.LogInformation($"{countryId} aaaaaaaa");
            return Ok(cityRepository.GetCitiesByCountryId(countryId).OrderBy(c => c.Name));
        }
    }
}
