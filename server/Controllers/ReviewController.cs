namespace PCpals.Controllers;

[ApiController]
[Route("api/pcBuilds")]

public class ReviewController{
    private readonly Auth0Provider auth;
    private readonly ReviewsService reviewsService;
    public ReviewController(Auth0Provider auth, ReviewsService reviewsService){
        this.auth = auth;
        this.reviewsService = reviewsService;
    }
}