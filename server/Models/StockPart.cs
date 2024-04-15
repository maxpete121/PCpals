namespace PCpals.Models;

public class StockPart : RepoItem<int>{
    public string ProductImage {get; set;}
    public string Type {get; set;}
    public string Size {get; set;}
    public decimal Price {get; set;}
    public string Name {get; set;}
    public string Company {get; set;}
    public string Speed {get; set;}
    public string Gigs {get; set;}
    public int PowerScore {get; set;}
    public int Watts {get; set;}
}

