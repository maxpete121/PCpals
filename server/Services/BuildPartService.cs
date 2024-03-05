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

    internal BuildPart GetBuildPartById(int buildPartId){
        BuildPart buildPart = repo.GetBuildPartById(buildPartId);
        return buildPart;
    }

    internal string DeleteBuildPart(int buildPartId, string userId){
        BuildPart buildPart = GetBuildPartById(buildPartId);
        if(userId == buildPart.CreatorId){
            repo.DeleteBuildPart(buildPartId);
            string message = "Part Removed";
            return message;
        }else{throw new Exception("Not Authorized");}
    }
}