namespace PCpals.Models;

public class Suggestion : RepoItem<int>{
    public int BuildId {get; set;}
    public PcBuild Build {get; set;}
}