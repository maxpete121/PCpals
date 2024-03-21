namespace PCpals.Services;

public class ReviewsService{
    private readonly ReviewRepository repo;
    public ReviewsService(ReviewRepository repo){
        this.repo = repo;
    }

    internal Reviews CreateReview(Reviews reviewData, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        Reviews newReview = repo.CreateReview(reviewData);
        return newReview;
    }

    internal Reviews GetReviewById(int reviewId){
        Reviews review = repo.GetReviewById(reviewId);
        return review;
    }

    internal List<Reviews> GetBuildReviews(int buildId){
        List<Reviews> reviews = repo.GetBuildReviews(buildId);
        return reviews;
    }

    internal string DeleteReview(int reviewId, string userId){
        Reviews foundReview = GetReviewById(reviewId);
        if(foundReview == null)throw new Exception("No review found with that Id.");
        else if(foundReview.CreatorId == userId){
            repo.DeleteReview(reviewId);
            string message = "Review Deleted.";
            return message;
        }else{throw new Exception("Not Authorized.");}
    }
}