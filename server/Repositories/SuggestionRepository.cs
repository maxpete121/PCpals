namespace PCpals.Repositories;

public class SuggestionRepository{
    private readonly IDbConnection db;
    public SuggestionRepository(IDbConnection db){
        this.db = db;
    }

    internal Suggestion CreateSuggestion(Suggestion suggestionData){
        string sql = @"
        INSERT INTO suggestions
        (creatorId, buildId, adminCode)
        VALUES
        (@creatorId, @buildId, @adminCode);

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

    internal Suggestion GetSuggestionById(int suggestionId){
        string sql = @"
        SELECT
        suggestions.*,
        pcBuilds.*
        FROM suggestions
        JOIN pcBuilds ON suggestions.buildId = pcBuilds.id
        WHERE suggestions.id = @suggestionId
        ";
        Suggestion suggestion = db.Query<Suggestion, PcBuild, Suggestion>(sql, (suggestion, pcBuild)=>{
            suggestion.Build = pcBuild;
            return suggestion;
        }, new{suggestionId}).FirstOrDefault();
        return suggestion;
    }

    internal void DeleteSuggestion(int suggestionId){
        string sql = @"
        DELETE FROM suggestions
        WHERE id = @suggestionId
        ";
        db.Execute(sql, new{suggestionId});
    }
}