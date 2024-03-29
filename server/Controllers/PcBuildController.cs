namespace PCpals.Controllers;

[ApiController]
[Route("api/pcBuilds")]

public class PcBuildController : ControllerBase
{
  private readonly Auth0Provider auth;
  private readonly PcBuildService pcBuildService;
  public PcBuildController(Auth0Provider auth, PcBuildService pcBuildService)
  {
    this.auth = auth;
    this.pcBuildService = pcBuildService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<PcBuild>> CreatePcBuild([FromBody] PcBuild pcBuildData)
  {
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
  public async Task<ActionResult<List<PcBuild>>> GetPersonalBuilds()
  {
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
  public async Task<ActionResult<string>> DeletePcBuild(int buildId)
  {
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

  [HttpGet("{pcId}")]
  public ActionResult<PcBuild> GetPcById(int pcId)
  {
    try
    {
      PcBuild pcBuild = pcBuildService.GetPcById(pcId);
      return pcBuild;
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPut("{pcId}/parts")]
  [Authorize]
  public async Task<ActionResult<PcBuild>> UpdateBuildParts([FromBody] PcBuild updateBuildData, int pcId)
  {
    try
    {
      Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
      PcBuild pcBuild = pcBuildService.UpdateBuildParts(updateBuildData, pcId, userInfo.Id);
      return Ok(pcBuild);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPut("{pcId}/share/update")]
  [Authorize]
  public async Task<ActionResult<PcBuild>> UpdateShare([FromBody] PcBuild buildData, int pcId)
  {
    try
    {
      Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
      PcBuild pcBuild = pcBuildService.UpdateShare(buildData, pcId, userInfo.Id);
      return Ok(pcBuild);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [HttpPut("{pcId}/powerScore")]
  [Authorize]
  public async Task<ActionResult<PcBuild>> UpdatePowerScore([FromBody] PcBuild updateData, int pcId)
  {
    try
    {
    Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
    PcBuild pcBuild = pcBuildService.UpdatePowerScore(updateData, pcId, userInfo.Id);
    return Ok(pcBuild);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpGet("shared")]
  public ActionResult<List<PcBuild>> GetAllSharedBuilds(){
    try
    {
      List<PcBuild> pcBuilds = pcBuildService.GetAllSharedBuilds();
      return Ok(pcBuilds);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPut("{buildId}/rating")]
  [Authorize]
  public async Task<ActionResult<PcBuild>> UpdateRating([FromBody] PcBuild updateData, int buildId){
    try
    {
      Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
      PcBuild pcBuild = pcBuildService.UpdateRating(updateData, buildId, userInfo.Id);
      return Ok(pcBuild);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}