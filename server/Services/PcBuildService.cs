namespace PCpals.Services;

public class PcBuildService{
    private readonly PcBuildRepository repo;
    public PcBuildService(PcBuildRepository repo){
        this.repo = repo;
    }

    internal PcBuild CreatePcBuild(PcBuild pcBuildData, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        PcBuild pcBuild = repo.CreatePcBuild(pcBuildData);
        return pcBuild;
    }

    internal List<PcBuild> GetPersonalBuilds(string userId){
        if(userId == null)throw new Exception("No user found");
        List<PcBuild> pcBuilds = repo.GetPersonalBuilds(userId);
        return pcBuilds;
    }

    internal PcBuild GetPcById(int pcId){
        PcBuild pcBuild = repo.GetPcById(pcId);
        return pcBuild;
    }

    internal string DeletePcBuild(int pcBuildId, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        repo.DeletePcBuild(pcBuildId);
        string message = "Build deleted.";
        return message;
    }

}