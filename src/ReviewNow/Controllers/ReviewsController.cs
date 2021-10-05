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
        public ReviewsController(IReviewRepository reviewRepository, IHostingEnvironment hostingEnv, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _hostingEnv = hostingEnv;
            _mapper = mapper;
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
                return Created("~", reviewExpDto);
            }

            return BadRequest();

        }

        [HttpDelete("{reviewIds}")]
        public IActionResult Delete(Guid reviewId)
        {
            if (_reviewRepository.Find(reviewId) == false) return NotFound();
            _reviewRepository.Delete(reviewId);
            return NoContent();
        }

    }
}