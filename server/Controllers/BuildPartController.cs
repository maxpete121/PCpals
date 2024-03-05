namespace PCpals.Controllers;

public class BuildPartController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly BuildPartService buildPartService;
    public BuildPartController(Auth0Provider auth, BuildPartService buildPartService){
        this.auth = auth;
        this.buildPartService = buildPartService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<BuildPart>> CreateBuildPart([FromBody]BuildPart buildPartData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            BuildPart buildPart = buildPartService.CreateBuildPart(buildPartData, userInfo.Id);
            return Ok(buildPart);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{pcId}")]
    public ActionResult<List<BuildPart>> GetPcBuildParts(int pcId){
        try
        {
            List<BuildPart> buildParts = buildPartService.GetPcBuildParts(pcId);
            return Ok(buildParts);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}