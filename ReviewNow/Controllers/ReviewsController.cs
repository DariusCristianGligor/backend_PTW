using Application;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController: ControllerBase
    {
        private readonly ILogger<ReviewsController> logger;
        private readonly IReviewRepository _reviewRepository;
        private readonly IHostingEnvironment _hostingEnv;

        public ReviewsController(ILogger<ReviewsController> logger,IReviewRepository reviewRepository, IHostingEnvironment hostingEnv)
        {
            this.logger = logger;
            _reviewRepository = reviewRepository;
            _hostingEnv = hostingEnv;
        }

        [HttpGet]
        public IActionResult Get(Guid placeId)
        {

            return Ok(_reviewRepository.GetAllReviewByPlaceId(placeId));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ReviewViewModel reviewVM)
        {
            if (reviewVM.Image != null)
            {
                var a = _hostingEnv.WebRootPath;
                var fileName = Path.GetFileName(reviewVM.Image.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Reviews", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await reviewVM.Image.CopyToAsync(fileSteam);
                }

                Review review = new Review();
                review.Id = new Guid();
                //maybe a erorr
                review.ImagePath = filePath;
                review.Place = reviewVM.Place;
                review.PlaceId = reviewVM.PlaceId;
                review.Stars = reviewVM.Stars;
                review.CostOfPlace = reviewVM.CostOfPlace;
                review.User = reviewVM.User;
                review.UserId = reviewVM.UserId;
                _reviewRepository.Add(review);
            }
            else
            {
                return BadRequest();
            }
            return Ok("I did it!!!!!");
        }

        [HttpDelete]
        public IActionResult Delete(Guid reviewId)
        {
            _reviewRepository.Delete(reviewId);
            return Ok("I did it!!!");
        }

    }
}
