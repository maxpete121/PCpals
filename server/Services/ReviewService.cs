namespace PCpals.Services;

public class ReviewsService{
    private readonly ReviewRepository repo;
    public ReviewsService(ReviewRepository repo){
        this.repo = repo;
    }
}