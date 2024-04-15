

namespace PCpals.Services;

public class SuggestionService{
    private readonly SuggestionRepository repo;

    public SuggestionService(SuggestionRepository repo){
        this.repo = repo;
    }
}