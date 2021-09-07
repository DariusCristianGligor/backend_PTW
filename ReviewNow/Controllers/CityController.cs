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
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class CityController: ControllerBase
    {
        private readonly ILogger<CityController> logger;
        private readonly ICityRepository cityRepository;

        public CityController(ILogger<CityController> logger,ICityRepository cityRepository)
        {
            this.logger = logger;
            this.cityRepository = cityRepository;
        }
        [HttpGet("get")]
        public IActionResult Get(Guid countryId)
        {
            Guid a = new Guid("1940F4E0-31A0-47B6-82CE-BB1C32A3ECB8");
            countryId = a;
            return Ok(cityRepository.GetCitiesByCountryId(countryId));
        }
        
    }
}
