namespace PCpals.Services;

public class SaveBuildService{
    private readonly SaveBuildRepository repo;
    public SaveBuildService(SaveBuildRepository repo){
        this.repo = repo;
    }
}