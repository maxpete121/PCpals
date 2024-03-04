namespace PCpals.Models;

public class BuildPart : RepoItem<int>{
    public int BuildId {get; set;}
    public string CreatorId {get; set;}
    public int PartId {get; set;}
    public StockPart Part {get; set;}
}