namespace PCpals.Repositories;

public class SuggestionRepository{
    private readonly IDbConnection db;
    public SuggestionRepository(IDbConnection db){
        this.db = db;
    }
}