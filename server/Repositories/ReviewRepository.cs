namespace PCpals.Repositories;

public class ReviewRepository{
    private readonly IDbConnection db;
    public ReviewRepository(IDbConnection db){
        this.db = db;
    }
}