using Application;
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
        
        [HttpGet]
        public IActionResult Get(Guid countryId)
        {
            Guid a = new Guid("1940F4E0-31A0-47B6-82CE-BB1C32A3ECB8");
            countryId = a;
            return Ok(cityRepository.GetCitiesByCountryId(countryId));
        }
        
    }
}
