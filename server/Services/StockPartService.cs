namespace PCpals.Services;

public class StockPartService{
    private readonly StockPartRepository repo;
    public  StockPartService(StockPartRepository repo){
        this.repo = repo;
    }
}