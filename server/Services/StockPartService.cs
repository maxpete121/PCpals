namespace PCpals.Services;

public class StockPartService{
    private readonly StockPartRepository repo;
    public  StockPartService(StockPartRepository repo){
        this.repo = repo;
    }

    internal StockPart CreateStockPart(StockPart stockPartData, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        StockPart stockPart = repo.CreateStockPart(stockPartData);
        return stockPart;
    }
    
    internal List<StockPart> GetPartsByType(string type){
        List<StockPart> stockParts = repo.GetPartsByType(type);
        return stockParts;
    }

    internal List<StockPart> GetIntelPartsByType(string type){
        List<StockPart> stockParts = repo.GetIntelPartsByType(type);
        return stockParts;
    }

        internal List<StockPart> GetAMDPartsByType(string type){
        List<StockPart> stockParts = repo.GetAMDPartsByType(type);
        return stockParts;
    }

    internal string DeleteStockPart(int partId, string userId){
        repo.DeleteStockPart(partId);
        string message = "Part removed.";
        return message;
    }
}