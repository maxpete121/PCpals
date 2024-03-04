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

    [HttpGet("account")]
    [Authorize]
    public async Task<ActionResult<List<PcBuild>>> GetPersonalBuilds(){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            List<PcBuild> pcBuilds = pcBuildService.GetPersonalBuilds(userInfo.Id);
            return Ok(pcBuilds);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpDelete("{buildId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeletePcBuild(int buildId){
        try
        {
          Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
          string message = pcBuildService.DeletePcBuild(buildId, userInfo.Id);
          return Ok(message);  
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}