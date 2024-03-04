namespace PCpals.Models;

public class PcBuild : RepoItem<int>{
    public string Name {get; set;}
    public string CreatorId {get; set;}
    public int PowerScore {get; set;}
    public decimal Price {get; set;}
    public int Rating {get; set;}
    public Account Creator {get; set;}
}