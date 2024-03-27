namespace PCpals.Models;

public class PcBuild : RepoItem<int>{
    public string Name {get; set;}
    public string CreatorId {get; set;}
    public int PowerScore {get; set;}
    public decimal Price {get; set;}
    public int Rating {get; set;}
    public Boolean IsPrivate {get; set;}
    public int Watts {get; set;}
    public string PcCase {get; set;}
    public string CasePicture {get; set;}
    public string PcCpu {get; set;}
    public string Gpu {get; set;}
    public string MotherBoard {get; set;}
    public string Ram {get; set;}
    public string PcStorage {get; set;}
    public string PowerSupply {get; set;}
    public string Cooler {get; set;}
    public Account Creator {get; set;}
}
