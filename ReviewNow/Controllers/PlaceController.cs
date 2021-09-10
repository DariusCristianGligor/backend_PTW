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
    public class PlaceController : ControllerBase
    {
        private readonly ILogger<PlaceController> logger;
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(ILogger<PlaceController> logger, IPlaceRepository placeRepository)
        {
            this.logger = logger;
            this._placeRepository = placeRepository;
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_placeRepository.GetAllOrderedByRating());
        }
        [HttpGet("getallplacesbycity")]
        public IActionResult GetAllPlacesByCityId(Guid id)
        {

            return Ok(_placeRepository.GetAllByCityId(id));
        }
        [HttpGet("getallplacesbycityandcategory")]
        public IActionResult GetAllPlacesByCityIdAndCategoryId(Guid city, ICollection<Guid> categories)
        {
            return Ok(_placeRepository.GetAllByCityIdAndCategoryId(city, categories));
        }
        [HttpGet("getallplacesbycategory")]
        public IActionResult GetAllPlacesByCategory(ICollection<Guid> categories)
        {
            return Ok(_placeRepository.GetAllByCategoryId(categories));
        }
        [HttpGet("getallplacesbycategoryandcountry")]
        public IActionResult GetAllPlacesByCategoryIdAndCountryId(ICollection<Guid> categories, Guid CountryId)
        {
            return Ok(_placeRepository.GetAllByCategoryIdAndCountryId(categories, CountryId));
        }

        [HttpPost("post")]
        public IActionResult Post(Place place)
        {
            _placeRepository.Add(place);
            return Ok("I added a new place");
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Guid placeId)
        {
            _placeRepository.delete(placeId);
            return Ok("I added a new place");
        }


    }
}
