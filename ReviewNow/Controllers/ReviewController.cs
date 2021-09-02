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
    public class ReviewController: ControllerBase
    {
        private readonly ILogger<ReviewController> logger;
        private readonly IReviewRepository reviewRepository;

        public ReviewController(ILogger<ReviewController> logger,IReviewRepository reviewRepository)
        {
            this.logger = logger;
            this.reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok();
        }
    }
}
