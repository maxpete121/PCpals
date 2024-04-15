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
}