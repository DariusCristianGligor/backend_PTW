using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using ReviewNow.ExportDtoClases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IMapper _mapper;
   
        private readonly IRecomandationService _recomandationService;

        public ReviewsController(IReviewRepository reviewRepository, IWebHostEnvironment hostingEnv, IMapper mapper, IRecomandationService recomandationService)
        {
            _reviewRepository = reviewRepository;
            _hostingEnv = hostingEnv;
            _mapper = mapper;
      
            _recomandationService = recomandationService;
        }

        [HttpGet("{placeId}")]
        public IActionResult Get(Guid placeId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            return Ok(_reviewRepository.GetAllReviewByPlaceId(placeId,page,pageSize));
        }

        [HttpGet("numberOfReviews{placeId}")]
        public IActionResult Get1(Guid placeId)
        {
            return Ok(_reviewRepository.GetNumberOfReview(placeId));
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ReviewDto reviewDto)
        {
            var imagePatsReview = new List<WrapperStringPathReview>();
            Review review = new Review();
            review= _mapper.Map<Review>(reviewDto);
            if (reviewDto.Image != null)
            {
               
                foreach (IFormFile image in reviewDto.Image)
                {
                    try
                    {
                        var a = _hostingEnv.WebRootPath;
                        var fileName = Path.GetFileName(image.FileName);
                        var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                        WrapperStringPathReview wrapperStringPathReview = new WrapperStringPathReview();
                        wrapperStringPathReview.Url = filePath;
                        imagePatsReview.Add(wrapperStringPathReview);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileSteam);
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
                review.ImagePaths = imagePatsReview;
            }
            await _reviewRepository.AddAsync(review);
            _recomandationService.RecalculateRating(review.PlaceId,review.Stars);
            return Ok(review);
        }

        [HttpDelete("{reviewIds}")]
        public IActionResult Delete(Guid reviewId)
        {
            Review review = _reviewRepository.Find(reviewId);
            if (review == null) return NotFound();
            {
                _recomandationService.RecalculateRatingDeleted(review.PlaceId, review.Stars);
                _reviewRepository.Delete(reviewId);
            }
            return NoContent();
        }

    }
}