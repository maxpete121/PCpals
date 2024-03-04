namespace PCpals.Services;

public class PcBuildService{
    private readonly PcBuildRepository repo;
    public PcBuildService(PcBuildRepository repo){
        this.repo = repo;
    }
}