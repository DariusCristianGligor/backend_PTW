using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReviewNow.ExportDtoClases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {

        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PlacesController> _logger;
        private readonly IWebHostEnvironment _hostingEnv;

        public WrapperStringPath WrapperStringPath { get; private set; }

        public PlacesController(IPlaceRepository placeRepository, IWebHostEnvironment hostingEnv, IMapper mapper, ILogger<PlacesController> logger)
        {
            _hostingEnv = hostingEnv;
            _logger = logger;
            _placeRepository = placeRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult Get([FromQuery]int page,[FromQuery] int pageSize)
        {
            return Ok(_placeRepository.GetAllOrderedByRating(page, pageSize));
        }

        [HttpGet("numberOfPlaces")]
        public IActionResult Get()
        {
            return Ok(_placeRepository.GetNumberOfPlace());
        }

        [HttpGet("{placeId}")]
        public IActionResult Get(Guid placeId)
        {
            Place place=_placeRepository.GetPlace(placeId);
            return Ok(place);
        }

        [HttpGet]
        public IActionResult GetAllPlacesByCityId([FromQuery] Guid cityId)
        {
            return Ok(_placeRepository.GetAllByCityId(cityId));
        }

        [HttpGet("all/categories/{cityId}")]
        public IActionResult GetAllPlacesByCityIdAndCategoryId([FromRoute] Guid cityId, [FromQuery] ICollection<Guid> categoryIds,[FromQuery]int page,[FromQuery]int pageSize)
        {
            return Ok(_placeRepository.GetAllByCityIdAndCategoryId(cityId, categoryIds, page,pageSize));
        }

        [HttpGet("allnumber/categories/{cityId}")]
        public IActionResult GetNumberOfPlacesWithPlaceIdandCategoryIds([FromRoute] Guid cityId, [FromQuery] ICollection<Guid> categoryIds)
        {
            return Ok(_placeRepository.NumberOfPlaceWithIdAndCategories(categoryIds, cityId));
        }

        [HttpGet("all/categories")]
        public IActionResult GetAllPlacesByCategory([FromQuery] ICollection<Guid> categoryIds)
        {
            return Ok(_placeRepository.GetAllByCategoryId(categoryIds));
        }

        [HttpGet("all/{cityId}")]
        public IActionResult GetAllPlacesByCategoryIdAndCountryId([FromRoute] Guid cityId, [FromQuery] ICollection<Guid> categories, [FromQuery] int page, [FromQuery] int pageSize)
        {
            return Ok(_placeRepository.GetAllByCategoryIdAndCityId(categories, cityId,page,pageSize));
        }
      
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PlaceDto placeDto)
        {
            var imagePatsPlace = new List<WrapperStringPath>();
            Place place = new Place();
            if (placeDto.Images != null)
            {
                _logger.LogInformation("nu e null");
                foreach (IFormFile image in placeDto.Images)
                {
                    try
                    {
                        var a = _hostingEnv.WebRootPath;
                        var fileName = Path.GetFileName(image.FileName);
                        var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                        WrapperStringPath wrapper = new WrapperStringPath();
                        wrapper.Url = filePath;
                        imagePatsPlace.Add(wrapper);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileSteam);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogInformation("in eroare");
                    }
                }
                _logger.LogInformation("aaaaa:", placeDto.Address);
            }

            //place = _mapper.Map<Place>(placeDto);
            var result = new StringBuilder();
            using (var reader = new StreamReader(placeDto.Categories.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            _logger.LogInformation("result este:",result);
            dynamic stuff = JsonConvert.DeserializeObject(result.ToString());
            var categories = new List<Category>();
            foreach(dynamic x in stuff)
            {
                JToken xx = x;
                string name = (string) xx["name"];
                Guid id = Guid.Parse((string)xx["id"]);
                string description = (string)xx["description"];
                DateTime addedDate = DateTime.Parse((string)xx["addedDateTime"]);
                DateTime updateDate = DateTime.Parse((string)xx["updatedDateTime"]);
                Category cat = new Category();
                cat.Name = name;
                cat.Id = id;
                cat.Description = description;
                cat.AddedDateTime = addedDate;
                cat.UpdatedDateTime = updateDate;
                cat.Places = new List<Place>();
                categories.Add(cat);
                _logger.LogInformation("asdasd");
            }
            place.Categories = categories;
            place.ImagePaths = imagePatsPlace;
            place.Address = placeDto.Address;
            place.AvgStars = 0;
            place.NumberOfReview = 0;
            place.Rating = 0;
            place.Name = placeDto.Name;
            place.CityId = placeDto.CityId;          
            await _placeRepository.AddAsync(place);
            return Ok(placeDto.Categories);
        }

        [HttpDelete("{placeId}")]
        public IActionResult Delete(Guid placeId)
        {
            if (_placeRepository.Find(placeId) == false)
                return NotFound();
            _placeRepository.Delete(placeId);
            return NoContent();
        }
    }
  
}
