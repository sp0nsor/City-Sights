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
        private readonly IReviewSrvice reviewService;

        public ReviewController(IReviewSrvice reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview([FromBody] ReviewRequest request)
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

            var result = await reviewService.CreateReview(reviewResult.Value);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<ActionResult> GetReviews([FromQuery] Guid id)
        {
            var result = await reviewService.GetReviews(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateReview(
            [FromQuery] Guid id, string title, string reviewText, int rating)
        {
            var result = await reviewService.UpdateReview(id, title, reviewText, rating);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReview([FromQuery] Guid id)
        {
            var result = await reviewService.DeleteReview(id);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
