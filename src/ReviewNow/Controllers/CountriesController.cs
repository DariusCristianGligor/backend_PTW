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
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> logger;
        private readonly ICountryRepository countryRepository;

        public CountriesController(ILogger<CountriesController> logger, ICountryRepository countryRepository)
        {
            this.logger = logger;
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get1()
        {
            return Ok(countryRepository.GetAllCountries().OrderBy(c=>c.Name));
        }

 
    }
}
