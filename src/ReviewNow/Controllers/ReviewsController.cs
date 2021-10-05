using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReviewNow.ExportDtoClases;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IMapper _mapper;
        private readonly IRecomandationService _recomandationService;

        public ReviewsController(IReviewRepository reviewRepository, IHostingEnvironment hostingEnv, IMapper mapper, IRecomandationService recomandationService)
        {
            _reviewRepository = reviewRepository;
            _hostingEnv = hostingEnv;
            _mapper = mapper;
            _recomandationService = recomandationService;
        }

        [HttpGet]
        public IActionResult Get(Guid placeId)
        {

            return Ok(_reviewRepository.GetAllReviewByPlaceId(placeId));
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ReviewDto reviewDto)
        {
            EntityEntry<Review> review;
            if (reviewDto.Image != null)
            {
                var a = _hostingEnv.WebRootPath;
                var fileName = Path.GetFileName(reviewDto.Image.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Reviews", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await reviewDto.Image.CopyToAsync(fileSteam);
                }
                Review review1 = _mapper.Map<Review>(reviewDto);
                review = await _reviewRepository.AddAsync(review1);
                ReviewExportDto reviewExpDto = _mapper.Map<ReviewExportDto>(review);
                _recomandationService.RecalculateRating(review1.PlaceId, reviewExpDto.Stars);
                return Created("~", reviewExpDto);
            }
            return BadRequest();
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