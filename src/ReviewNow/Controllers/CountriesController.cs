using Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {

            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get1()
        {
            return Ok(countryRepository.GetAllCountries().OrderBy(c => c.Name));
        }


    }
}
