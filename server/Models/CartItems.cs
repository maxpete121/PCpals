namespace PCpals.Models;

public class CartItems : RepoItem<int>{
    public string CreatorId {get; set;}
    public int BuildId {get; set;}
    public PcBuild Build {get; set;}
}