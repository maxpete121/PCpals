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

    internal PcBuild UpdateBuildParts(PcBuild updateBuildData ,int pcId,string userId){
        PcBuild originalPc = GetPcById(pcId);
        if(originalPc == null)throw new Exception("PC ID is invalid.");
        else if(originalPc.CreatorId == userId){
        originalPc.PcCase = updateBuildData.PcCase?.Length > 0 ? updateBuildData.PcCase : originalPc.PcCase;
        originalPc.CasePicture = updateBuildData.CasePicture?.Length > 0 ? updateBuildData.CasePicture : originalPc.CasePicture;
        originalPc.PcCpu = updateBuildData.PcCpu?.Length > 0 ? updateBuildData.PcCpu : originalPc.PcCpu;
        originalPc.Gpu = updateBuildData.Gpu?.Length > 0 ? updateBuildData.Gpu : originalPc.Gpu;
        originalPc.MotherBoard = updateBuildData.MotherBoard?.Length > 0 ? updateBuildData.MotherBoard : originalPc.MotherBoard;
        originalPc.Ram = updateBuildData.Ram?.Length > 0 ? updateBuildData.Ram : originalPc.Ram;
        originalPc.PcStorage = updateBuildData.PcStorage?.Length > 0 ? updateBuildData.PcStorage : originalPc.PcStorage;
        originalPc.PowerSupply = updateBuildData.PowerSupply?.Length > 0 ? updateBuildData.PowerSupply : originalPc.PowerSupply;
        PcBuild newPcBuild = repo.UpdateBuildParts(originalPc);
        return newPcBuild;
        }else{throw new Exception("Not Authorized");}
    }

    internal PcBuild UpdateShare(PcBuild buildData,int pcId, string userId){
        PcBuild originalPc = GetPcById(pcId);
        if(originalPc.CreatorId == userId){
            originalPc.IsPrivate = buildData.IsPrivate != originalPc.IsPrivate ? buildData.IsPrivate : originalPc.IsPrivate;
            PcBuild newBuild = repo.UpdateShare(originalPc);
            return newBuild;
        }else{throw new Exception("Not Authorized");}
    }

    internal PcBuild UpdatePowerScore(PcBuild updateData, int pcId, string userId){
        PcBuild originalPc = GetPcById(pcId);
        if(originalPc == null)throw new Exception("No PC found with that Id.");
        if(originalPc.CreatorId == userId){
            originalPc.PowerScore = updateData.PowerScore;
            originalPc.Price = updateData.Price;
            originalPc.Watts = updateData.Watts;
            originalPc.MaxWattage = updateData.MaxWattage;
            PcBuild updatedData = repo.UpdatePowerScore(originalPc);
            return updatedData;
        }else{throw new Exception("Not Authorized.");}
    }

    internal List<PcBuild> GetAllSharedBuilds(){
        List<PcBuild> pcBuilds = repo.GetAllSharedBuilds();
        return pcBuilds;
    }

    internal PcBuild UpdateRating(PcBuild updateData, int buildId, string userId){
        PcBuild originalBuild = GetPcById(buildId);
        if(originalBuild == null)throw new Exception("No Pc found with that Id");
        originalBuild.Rating = updateData.Rating;
        PcBuild updatedBuild = repo.UpdateRating(originalBuild);
        return updatedBuild;
    }

}