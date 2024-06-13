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

    internal List<StockPart> GetCpuPartsByType(string type){
        List<StockPart> stockParts = repo.GetCpuPartsByType(type);
        return stockParts;
    }

    internal List<StockPart>  GetMotherBoards(string parameter){
        List<StockPart> stockParts = repo. GetMotherBoards(parameter);
        return stockParts;
    }

    internal string DeleteStockPart(int partId, string userId){
        repo.DeleteStockPart(partId);
        string message = "Part removed.";
        return message;
    }
}