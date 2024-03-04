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
}