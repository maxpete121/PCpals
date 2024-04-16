

namespace PCpals.Services;

public class SuggestionService{
    private readonly SuggestionRepository repo;

    public SuggestionService(SuggestionRepository repo){
        this.repo = repo;
    }

    internal Suggestion CreateSuggestion(Suggestion suggestionData){
        Suggestion suggestion = repo.CreateSuggestion(suggestionData);
        return suggestion;
    }
}