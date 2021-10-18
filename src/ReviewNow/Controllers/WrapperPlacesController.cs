using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WrapperPlacesController : ControllerBase
    {

        private readonly IWrapperPlaceRepository _wrapperPlaceRepository;


        public WrapperPlacesController(IWrapperPlaceRepository wrapperPlaceRepository)
        {
            _wrapperPlaceRepository = wrapperPlaceRepository;
        }
        [HttpGet("{placeId}")]
        public IActionResult Index(Guid placeId)
        {
            var listOfUrl=_wrapperPlaceRepository.GetAll(placeId).ToList();
            var listOfImage = new List<byte[]>();
            foreach (WrapperStringPath a in listOfUrl)
            {
                ImageConverter converter = new ImageConverter();
                byte[] bytes = System.IO.File.ReadAllBytes(a.Url);
                listOfImage.Add(bytes);
            }
            return Ok(listOfImage);
        }

    }
}
