using Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {

            this.cityRepository = cityRepository;
        }

        [HttpGet("{countryId}")]
        public IActionResult Get(Guid countryId)
        {
            return Ok(cityRepository.GetCitiesByCountryId(countryId));
        }
    }
}
