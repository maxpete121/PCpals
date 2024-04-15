namespace PCpals.Controllers;


public class SaveBuildController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly SaveBuildService saveBuildService;
    public SaveBuildController(Auth0Provider auth, SaveBuildService saveBuildService){
        this.auth = auth;
        this.saveBuildService = saveBuildService;
    }
}