namespace PCpals.Repositories;


public class StockPartRepository{
    private readonly IDbConnection db;

    public StockPartRepository(IDbConnection db){
        this.db = db;
    }

    internal StockPart CreateStockPart(){
        string sql = @"";
    }
}