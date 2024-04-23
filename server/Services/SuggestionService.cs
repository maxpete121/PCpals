

namespace PCpals.Services;

public class SuggestionService{
    private readonly SuggestionRepository repo;

    public SuggestionService(SuggestionRepository repo){
        this.repo = repo;
    }

    internal Suggestion CreateSuggestion(Suggestion suggestionData){
        if(suggestionData.AdminCode == 17448){
        Suggestion suggestion = repo.CreateSuggestion(suggestionData);
        return suggestion;
        }else if(suggestionData == null){throw new Exception("No data found in request body.");}
        else{throw new Exception("You are not authorized to make this request!");}
    }

    internal List<Suggestion> GetSuggestions(){
        List<Suggestion> suggestions = repo.GetSuggestions();
        return  suggestions;
    }
}