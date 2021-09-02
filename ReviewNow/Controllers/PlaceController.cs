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
    public class PlaceController : ControllerBase
    {
        private readonly ILogger<PlaceController> logger;
        private readonly IPlaceRepository placeRepository;

        public PlaceController(ILogger<PlaceController> logger,IPlaceRepository placeRepository)
        {
            this.logger = logger;
            this.placeRepository = placeRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(placeRepository.GetAllOrderedByRating());
        }
    }
}
