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
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly ILogger<PlacesController> logger;
        private readonly IPlaceRepository _placeRepository;

        public PlacesController(ILogger<PlacesController> logger, IPlaceRepository placeRepository)
        {
            this.logger = logger;
            this._placeRepository = placeRepository;
        }
        
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_placeRepository.GetAllOrderedByRating());
        }

        [HttpGet]
        public IActionResult GetAllPlacesByCityId([FromQuery] Guid cityId)
        {
        return Ok(_placeRepository.GetAllByCityId(cityId));
        }

        [HttpGet("all/categories/{cityId}")]
        public IActionResult GetAllPlacesByCityIdAndCategoryId([FromRoute]Guid cityId, [FromQuery] ICollection<Guid> categoryIds)
        {
            return Ok(_placeRepository.GetAllByCityIdAndCategoryId(cityId, categoryIds));
        }

        [HttpGet("all/categories")]
        public IActionResult GetAllPlacesByCategory([FromQuery] ICollection<Guid> categoryIds)
        {
            return Ok(_placeRepository.GetAllByCategoryId(categoryIds));
        }

        [HttpGet("all/{countryId}")]
        public IActionResult GetAllPlacesByCategoryIdAndCountryId([FromRoute] Guid countryId, [FromQuery] ICollection<Guid> categories)
        {
            return Ok(_placeRepository.GetAllByCategoryIdAndCountryId(categories, countryId));
        }

        [HttpPost]
        public IActionResult Post(Place place)
        {
            _placeRepository.Add(place);
            return Ok("I added a new place");
        }

        [HttpDelete]
        public IActionResult Delete(Guid placeId)
        {
            _placeRepository.delete(placeId);
            return Ok("I added a new place");
        }


    }
}
