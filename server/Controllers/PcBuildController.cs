namespace PCpals.Controllers;

[ApiController]
[Route("api/pcBuilds")]

public class PcBuildController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly PcBuildService pcBuildService;
    public PcBuildController(Auth0Provider auth, PcBuildService pcBuildService){
        this.auth = auth;
        this.pcBuildService = pcBuildService;
    }
}