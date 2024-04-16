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
            Suggestion suggestion = suggestionService.CreateSuggestion(suggestionData);
            return Ok(suggestion);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}