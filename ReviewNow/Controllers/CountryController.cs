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
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> logger;
        private readonly ICountryRepository countryRepository;

        public CountryController(ILogger<CountryController> logger, ICountryRepository countryRepository)
        {
            this.logger = logger;
            this.countryRepository = countryRepository;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {

            return Ok(countryRepository.GetAllCountriesWithCities());
        }
        [HttpGet("getcountries")]
        public IActionResult Get1()
        {

            return Ok(countryRepository.GetAllCountries());
        }
    }
}
