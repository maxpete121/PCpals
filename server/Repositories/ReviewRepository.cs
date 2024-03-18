namespace PCpals.Repositories;

public class ReviewRepository{
    private readonly IDbConnection db;
    public ReviewRepository(IDbConnection db){
        this.db = db;
    }

    internal Reviews CreateReview(PcBuild buildData){
        string sql = @"
        INSERT INTO reviews
        (creatorId, buildId, body, stars)
        VALUES
        (@creatorId, @buildId, @body, @stars);

        SELECT
        reviews.*,
        accounts.*
        FROM reviews
        JOIN accounts ON reviews.creatorId = accounts.id
        WHERE reviews.id = LAST_INSERT_ID()
        ";
        Reviews review = db.Query<Reviews, Account, Reviews>(sql, (review, account)=>{
            review.Creator = account;
            return review;
        }, buildData).FirstOrDefault();
        return review;
    }
}





