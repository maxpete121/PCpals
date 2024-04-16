namespace PCpals.Repositories;

public class SaveBuildRepository{
    private IDbConnection db;
    public SaveBuildRepository(IDbConnection db){
        this.db = db;
    }

    internal SaveBuild CreateSaveBuild(SaveBuild saveBuildData){
        string sql = @"
        INSERT INTO saveBuilds
        (creatorId, buildId)
        VALUES
        (@creatorId, @buildId);

        SELECT
        saveBuilds.*,
        pcBuilds.*
        FROM saveBuilds
        JOIN pcBuilds ON saveBuilds.buildId = pcBuilds.id
        WHERE saveBuilds.id = LAST_INSERT_ID()
        ";
        SaveBuild saveBuild = db.Query<SaveBuild, PcBuild, SaveBuild>(sql, (saveBuild, pcBuild)=>{
            saveBuild.Build = pcBuild;
            return saveBuild;
        }, saveBuildData).FirstOrDefault();
        return saveBuild;
    }

    internal SaveBuild GetSaveBuildById(int saveBuildId){
        string sql = @"
        SELECT
        saveBuilds.*,
        pcBuilds.*
        FROM saveBuilds
        JOIN pcBuilds ON saveBuilds.buildId = pcBuilds.id
        WHERE saveBuilds.id = @saveBuildId
        ";
        SaveBuild saveBuild = db.Query<SaveBuild, PcBuild, SaveBuild>(sql, (saveBuild, pcBuild)=>{
            saveBuild.Build = pcBuild;
            return saveBuild;
        }, new{saveBuildId}).FirstOrDefault();
        return saveBuild;
    }

    internal List<SaveBuild> GetUserSavedBuilds(string userId){
        string sql = @"
        SELECT
        saveBuilds.*,
        pcBuilds.*
        FROM saveBuilds
        JOIN pcBuilds ON saveBuilds.buildId = pcBuilds.id
        WHERE saveBuilds.creatorId = @userId
        ";

        List<SaveBuild> saveBuild = db.Query<SaveBuild, PcBuild, SaveBuild>(sql, (saveBuild, pcBuild)=>{
            saveBuild.Build = pcBuild;
            return saveBuild;
        }, new{userId}).ToList();
        return saveBuild;
    }

    internal void DeleteSaveBuild(int saveId){
        string sql = @"
        DELETE FROM saveBuilds
        WHERE id = @saveId
        ";
        db.Execute(sql, new{saveId});
    }
}