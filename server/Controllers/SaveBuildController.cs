namespace PCpals.Controllers;

[ApiController]
[Route("api/saveBuilds")]
public class SaveBuildController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly SaveBuildService saveBuildService;
    public SaveBuildController(Auth0Provider auth, SaveBuildService saveBuildService){
        this.auth = auth;
        this.saveBuildService = saveBuildService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SaveBuild>> CreateSaveBuild([FromBody]SaveBuild saveBuildData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            SaveBuild saveBuild = saveBuildService.CreateSaveBuild(saveBuildData, userInfo.Id);
            return Ok(saveBuild);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{saveBuildId}")]
    public ActionResult<SaveBuild> GetSaveBuildById(int saveBuildId){
        try
        {
            SaveBuild saveBuild = saveBuildService.GetSaveBuildById(saveBuildId);
            return Ok(saveBuild);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("userBuilds")]
    [Authorize]
    public async Task<ActionResult<List<SaveBuild>>> GetUserSavedBuilds(){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext); 
            List<SaveBuild> saveBuilds = saveBuildService.GetUserSavedBuilds(userInfo.Id);
            return Ok(saveBuilds);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpDelete("{saveId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteSaveBuild(int saveId){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = saveBuildService.DeleteSaveBuild(saveId, userInfo.Id);
            return Ok(message);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}