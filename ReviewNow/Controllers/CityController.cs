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
        [HttpGet]
        public IActionResult Get()
        {
            Guid a = new Guid("1940F4E0-31A0-47B6-82CE-BB1C32A3ECB8");
            return Ok(cityRepository.GetCitiesByCountryId(a));
        }
    }
}
