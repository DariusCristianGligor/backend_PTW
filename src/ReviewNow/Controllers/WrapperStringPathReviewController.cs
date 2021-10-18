using Application;
using Microsoft.AspNetCore.Mvc;
using System;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WrapperStringPathReviewController : ControllerBase
    {

        private readonly IWrapperStringPathReviewRepository _wrapperStringPathReviewRepository;


        public WrapperStringPathReviewController(IWrapperStringPathReviewRepository wrapperStringPathReviewRepository)
        {
            _wrapperStringPathReviewRepository = wrapperStringPathReviewRepository;
        }

        [HttpGet("{reviewId}")]
        public IActionResult Index(Guid reviewId)
        {
            var listOfUrl = _wrapperStringPathReviewRepository.GetAll(reviewId).ToList();
            var listOfImage = new List<byte[]>();
            foreach (WrapperStringPathReview a in listOfUrl)
            {
                ImageConverter converter = new ImageConverter();
                byte[] bytes = System.IO.File.ReadAllBytes(a.Url);
                listOfImage.Add(bytes);
            }
            return Ok(listOfImage);
        }
    }
}