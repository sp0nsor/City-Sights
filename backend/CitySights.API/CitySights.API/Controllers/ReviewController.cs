using CitySights.API.Contracts;
using CitySights.Application.Services;
using CitySights.Core.Models;
using CitySights.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CitySights.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewSrvice reviewSrvice;

        public ReviewController(IReviewSrvice reviewSrvice)
        {
            this.reviewSrvice = reviewSrvice;
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewRequest request)
        {
            var reviewResult = Review.Create(
                Guid.NewGuid(),
                request.SightId,
                request.Title,
                request.ReviewText,
                request.Rating);

            if (reviewResult.IsFailure)
            {
                return BadRequest(reviewResult.Error);
            }

            var responseResult = await reviewSrvice.CreateReview(reviewResult.Value);

            if(responseResult.IsFailure)
            {
                return BadRequest(responseResult.Error);
            }

            return Ok(responseResult.Value);
        }
    }
}
