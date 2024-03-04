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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PcBuild>> CreatePcBuild([FromBody]PcBuild pcBuildData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            PcBuild pcBuild = pcBuildService.CreatePcBuild(pcBuildData, userInfo.Id);
            return Ok(pcBuild);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}