namespace PCpals.Models;

public class StockPart{
    public string ProductImage {get; set;}
    public string Type {get; set;}
    public string Size {get; set;}
    public int Price {get; set;}
    public string Name {get; set;}
    public string Company {get; set;}
    public string Speed {get; set;}
    public string Gigs {get; set;}
    public int PowerScore {get; set;}
}


// {
// "productImage":"https://m.media-amazon.com/images/I/71tduSp8ooL._AC_SX466_.jpg",
// "type":"gpu",
// "size":"none",
// "price":{"$numberDouble":"289.39"},
// "name":"MSI Gaming GeForce RTX 3060 12GB",
// "company":"MSI",
// "speed":"",
// "gigs":"12GB",
// "powerScore": 100
// }