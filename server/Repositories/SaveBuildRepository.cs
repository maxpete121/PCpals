namespace PCpals.Repositories;

public class SaveBuildRepository{
    private IDbConnection db;
    public SaveBuildRepository(IDbConnection db){
        this.db = db;
    }

    internal SaveBuild CreateSaveBuild(SaveBuild saveBuildData){
        string sql = @"
        INSERT INTO saveBuild
        (creatorId, buildId)
        VALUES
        (@creatorId, @buildId);

        SELECT
        saveBuild.*,
        pcBuilds.*
        FROM saveBuild
        JOIN pcBuilds ON saveBuild.buildId = pcBuilds.id
        WHERE saveBuild.id = LAST_INSERT_ID()
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
        saveBuild.*,
        pcBuilds.*
        FROM saveBuild
        JOIN pcBuilds ON saveBuild.buildId = pcBuilds.id
        WHERE saveBuild.id = @saveBuildId
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
        saveBuild.*,
        pcBuilds.*
        FROM saveBuild
        JOIN pcBuilds ON saveBuild.buildId = pcBuilds.id
        WHERE saveBuild.creatorId = @userId
        ";

        List<SaveBuild> saveBuild = db.Query<SaveBuild, PcBuild, SaveBuild>(sql, (saveBuild, pcBuild)=>{
            saveBuild.Build = pcBuild;
            return saveBuild;
        }, new{userId}).ToList();
        return saveBuild;
    }

    internal void DeleteSaveBuild(int saveId){
        string sql = @"
        DELETE FROM saveBuild
        WHERE id = @saveId
        ";
        db.Execute(sql, new{saveId});
    }
}