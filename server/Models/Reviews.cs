namespace PCpals.Models;

public class Reviews : RepoItem<int>{
    public string CreatorId {get; set;}
    public int BuildId {get; set;}
    public string Body {get; set;}
    public int Stars {get; set;}
}