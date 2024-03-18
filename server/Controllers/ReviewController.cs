using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace PCpals.Controllers;

[ApiController]
[Route("api/reviews")]

public class ReviewController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly ReviewsService reviewsService;
    public ReviewController(Auth0Provider auth, ReviewsService reviewsService){
        this.auth = auth;
        this.reviewsService = reviewsService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Reviews>> CreateReview([FromBody]PcBuild buildData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            Reviews review = reviewsService.CreateReview(buildData, userInfo.Id);
            return Ok(review);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{reviewId}")]
    public ActionResult<Reviews> GetReviewById(int reviewId){
        try
        {
            Reviews review = reviewsService.GetReviewById(reviewId);
            return Ok(review);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{buildId}/build")]
    public ActionResult<List<Reviews>> GetBuildReviews(int buildId){
        try
        {
            List<Reviews> reviews = reviewsService.GetBuildReviews(buildId);
            return Ok(reviews);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpDelete("{reviewId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteReview(int reviewId){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = reviewsService.DeleteReview(reviewId, userInfo.Id);
            return Ok(message);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}