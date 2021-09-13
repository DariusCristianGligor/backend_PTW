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
    public class ReviewsController: ControllerBase
    {
        private readonly ILogger<ReviewsController> logger;
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(ILogger<ReviewsController> logger,IReviewRepository reviewRepository)
        {
            this.logger = logger;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult Get(Guid placeId)
        {

            return Ok(_reviewRepository.GetAllReviewByPlaceId(placeId));
        }

        [HttpPost]
        public IActionResult Post(Review review)
        {
            _reviewRepository.Add(review);
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
