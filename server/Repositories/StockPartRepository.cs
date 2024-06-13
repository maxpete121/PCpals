namespace PCpals.Repositories;


public class StockPartRepository{
    private readonly IDbConnection db;

    public StockPartRepository(IDbConnection db){
        this.db = db;
    }

    internal StockPart CreateStockPart(StockPart stockPartData){
        string sql = @"
        INSERT INTO stockParts
        (productImage, type, size, price, name, company, speed, gigs, powerScore, watts, chipSet)
        VALUES
        (@productImage, @type, @size, @price, @name, @company, @speed, @gigs, @powerScore, @watts, chipSet);

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

    internal List<StockPart> GetIntelPartsByType(string type){
        string sql = @"
        SELECT
        *
        FROM stockParts
        WHERE type = @type AND company = 'Intel'
        ";
        List<StockPart> stockParts = db.Query<StockPart>(sql, new{type}).ToList();
        return stockParts;
    }

    internal List<StockPart> GetMotherBoards(object parameter){
        string sql = @"
        SELECT
        *
        FROM stockParts
        WHERE type = @type AND chipSet = @chipSet
        ";
        List<StockPart> stockParts = db.Query<StockPart>(sql, parameter).ToList();
        return stockParts;
    }
    
    internal List<StockPart> GetAMDPartsByType(string type){
        string sql = @"
        SELECT
        *
        FROM stockParts
        WHERE type = @type AND company = 'AMD'
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