namespace PCpals.Services;

public class BuildPartService{
    private readonly BuildPartRepository repo;
    public BuildPartService(BuildPartRepository repo){
        this.repo = repo;
    }

    internal BuildPart CreateBuildPart(BuildPart buildPartData, string userId){
        if(userId == null)throw new Exception("Not Authorized");
        BuildPart buildPart = repo.CreateBuildPart(buildPartData);
        return buildPart;
    }

    internal List<BuildPart> GetPcBuildParts(int pcId){
        List<BuildPart> buildParts = repo.GetPcBuildParts(pcId);
        return buildParts;
    }
}