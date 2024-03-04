namespace PCpals.Repositories;

public class PcBuildRepository{
    private readonly IDbConnection db;
    public PcBuildRepository(IDbConnection db){
        this.db = db;
    }
}