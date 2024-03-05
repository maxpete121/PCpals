namespace PCpals.Repositories;

public class BuildPartRepository{
    private readonly IDbConnection db;
    public BuildPartRepository(IDbConnection db){
        this.db = db;
    }

    internal BuildPart CreateBuildPart(BuildPart buildPartData){
        string sql = @"
        INSERT INTO buildParts
        (buildId, creatorId, partId)
        VALUES
        (@buildId, @creatorId, @partId);

        SELECT
        buildParts.*,
        stockParts.*
        FROM buildParts
        JOIN stockParts ON buildParts.partId = stockParts.id
        WHERE buildParts.id = LAST_INSERT_ID()
        ";
        BuildPart buildPart = db.Query<BuildPart, StockPart, BuildPart>(sql, (buildPart, stockPart)=>{
            buildPart.Part = stockPart;
            return buildPart;
        }, buildPartData).FirstOrDefault();
        return buildPart;
    }

    internal List<BuildPart> GetPcBuildParts(int pcId){
        string sql = @"
        SELECT
        buildParts.*,
        stockParts.*
        FROM buildParts
        JOIN stockParts ON buildParts.partId = stockParts.id
        WHERE buildParts.buildId = @pcId
        ";
        List<BuildPart> buildParts = db.Query<BuildPart, StockPart, BuildPart>(sql, (buildPart, stockPart)=>{
            buildPart.Part = stockPart;
            return buildPart;
        }, new{pcId}).ToList();
        return buildParts;
    }
}