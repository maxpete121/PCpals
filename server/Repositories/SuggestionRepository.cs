namespace PCpals.Repositories;

public class SuggestionRepository{
    private readonly IDbConnection db;
    public SuggestionRepository(IDbConnection db){
        this.db = db;
    }

    internal Suggestion CreateSuggestion(Suggestion suggestionData){
        string sql = @"
        INSERT INTO saveBuilds
        (creatorId, buildId)
        VALUES
        (@creatorId, @buildId);

        SELECT
        suggestions.*,
        pcBuilds.*
        FROM suggestions
        JOIN pcBuilds ON suggestions.buildId = pcBuilds.id
        WHERE suggestions.id = LAST_INSERT_ID()
        ";
        Suggestion suggestion = db.Query<Suggestion, PcBuild, Suggestion>(sql, (suggestion, pcBuild)=>{
            suggestion.Build = pcBuild;
            return suggestion;
        }, suggestionData).FirstOrDefault();
        return suggestion;
    }

    internal List<Suggestion> GetSuggestions(){
        string sql = @"
        SELECT
        suggestions.*,
        pcBuilds.*
        FROM suggestions
        JOIN pcBuilds ON suggestions.buildId = pcBuilds.id
        WHERE suggestions.adminCode = 17448
        ";
        List<Suggestion> suggestion = db.Query<Suggestion, PcBuild, Suggestion>(sql, (suggestion, pcBuild)=>{
            suggestion.Build = pcBuild;
            return suggestion;
        }).ToList();
        return suggestion;
    }
}