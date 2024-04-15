namespace PCpals.Repositories;

public class SaveBuildRepository{
    private IDbConnection db;
    public SaveBuildRepository(IDbConnection db){
        this.db = db;
    }
}