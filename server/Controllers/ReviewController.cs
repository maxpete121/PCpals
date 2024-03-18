using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace PCpals.Controllers;

[ApiController]
[Route("api/reviews")]

public class ReviewController{
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
            return review;
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}