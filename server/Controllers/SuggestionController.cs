namespace PCpals.Controllers;

[ApiController]
[Route("api/suggestions")]

public class SuggestionController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly SuggestionService suggestionService;
    public SuggestionController(Auth0Provider auth, SuggestionService suggestionService){
        this.auth = auth;
        this.suggestionService = suggestionService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Suggestion>> CreateSuggestion([FromBody] Suggestion suggestionData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            suggestionData.CreatorId = userInfo.Id; 
            Suggestion suggestion = suggestionService.CreateSuggestion(suggestionData);
            return Ok(suggestion);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Suggestion>> GetSuggestions(){
        try
        {
            List<Suggestion> suggestions = suggestionService.GetSuggestions();
            return Ok(suggestions);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{suggestionId}")]
    public ActionResult<Suggestion> GetSuggestionById(int suggestionId){
        try
        {
            Suggestion suggestion = suggestionService.GetSuggestionById(suggestionId);
            return Ok(suggestion);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpDelete("{suggestionId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteSuggestion(int suggestionId){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = suggestionService.DeleteSuggestion(suggestionId, userInfo.Id);
            return message;
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}