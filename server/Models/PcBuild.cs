namespace PCpals.Models;

public class PcBuild{
    public string Name {get; set;}
    public string CreatorId {get; set;}
    public int PowerScore {get; set;}
    public int Price {get; set;}
    public int Rating {get; set;}
    public Account Creator {get; set;}
}