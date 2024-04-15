namespace PCpals.Services;

public class SaveBuildService{
    private readonly SaveBuildRepository repo;
    public SaveBuildService(SaveBuildRepository repo){
        this.repo = repo;
    }
    internal SaveBuild CreateSaveBuild(SaveBuild saveBuildData, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        SaveBuild newSaveBuild = repo.CreateSaveBuild(saveBuildData);
        return newSaveBuild;
    }

    internal SaveBuild GetSaveBuildById(int saveBuildId){
        SaveBuild saveBuild = repo.GetSaveBuildById(saveBuildId);
        return saveBuild;
    }

    internal List<SaveBuild> GetUserSavedBuilds(string userId){
        List<SaveBuild> saveBuilds = repo.GetUserSavedBuilds(userId);
        return saveBuilds;
    }
}