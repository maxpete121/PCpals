namespace PCpals.Repositories;

public class ReviewRepository{
    private readonly IDbConnection db;
    public ReviewRepository(IDbConnection db){
        this.db = db;
    }

    internal Reviews CreateReview(PcBuild buildData){
        string sql = @"
        INSERT INTO reviews
        (creatorId, buildId, body, stars, title)
        VALUES
        (@creatorId, @buildId, @body, @stars, @title);

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

    internal Reviews GetReviewById(int reviewId){
        string sql = @"
        SELECT
        reviews.*,
        accounts.*
        FROM reviews
        JOIN accounts ON reviews.creatorId = accounts.id
        WHERE reviews.id = @reviewId
        ";
        Reviews review = db.Query<Reviews, Account, Reviews>(sql, (review, account)=>{
            review.Creator = account;
            return review;
        }, new{reviewId}).FirstOrDefault();
        return review;
    }

    internal List<Reviews> GetBuildReviews(int buildId){
        string sql = @"
        SELECT
        reviews.*,
        accounts.*
        FROM reviews
        JOIN accounts ON reviews.creatorId = accounts.id
        WHERE reviews.id = @buildId
        ";
        List<Reviews> reviews = db.Query<Reviews, Account, Reviews>(sql, (review, account)=>{
            review.Creator = account;
            return review;
        }, new{buildId}).ToList();
        return reviews;
    }

    internal void DeleteReview(int reviewId){
        string sql = @"
        DELETE FROM reviews
        WHERE id = @reviewId
        ";
        db.Execute(sql, new{reviewId});
    }
}





