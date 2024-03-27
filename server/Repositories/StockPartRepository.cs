namespace PCpals.Repositories;


public class StockPartRepository{
    private readonly IDbConnection db;

    public StockPartRepository(IDbConnection db){
        this.db = db;
    }

    internal StockPart CreateStockPart(StockPart stockPartData){
        string sql = @"
        INSERT INTO stockParts
        (productImage, type, size, price, name, company, speed, gigs, powerScore, watts)
        VALUES
        (@productImage, @type, @size, @price, @name, @company, @speed, @gigs, @powerScore, @watts);

        SELECT
        *
        FROM stockParts
        WHERE id = LAST_INSERT_ID()
        ";
        StockPart stockPart = db.Query<StockPart>(sql, stockPartData).FirstOrDefault();
        return stockPart;
    }

    internal List<StockPart> GetPartsByType(string type){
        string sql = @"
        SELECT
        *
        FROM stockParts
        WHERE type = @type
        ";
        List<StockPart> stockParts = db.Query<StockPart>(sql, new{type}).ToList();
        return stockParts;
    }

    internal void DeleteStockPart(int partId){
        string sql = @"
        DELETE FROM stockParts
        WHERE id = @partId
        ";
        db.Execute(sql, new{partId});
    }
}