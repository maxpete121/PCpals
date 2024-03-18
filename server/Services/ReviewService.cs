namespace PCpals.Services;

public class ReviewsService{
    private readonly ReviewRepository repo;
    public ReviewsService(ReviewRepository repo){
        this.repo = repo;
    }

    internal Reviews CreateReview(PcBuild buildData, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        Reviews newReview = repo.CreateReview(buildData);
        return newReview;
    }
}