using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PCpals.Controllers;

[ApiController]
[Route("api/stockParts")]

public class StockPartController : ControllerBase{
    private readonly StockPartService stockPartService;
    private readonly Auth0Provider auth;
    public StockPartController(StockPartService stockPartService, Auth0Provider auth){
        this.auth = auth;
        this.stockPartService = stockPartService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<StockPart>> CreateStockPart([FromBody]StockPart stockPartData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            StockPart stockPart = stockPartService.CreateStockPart(stockPartData, userInfo.Id);
            return Ok(stockPart);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{type}")]
    public ActionResult<List<StockPart>> GetPartsByType(string type){
        try
        {
           List<StockPart> stockParts = stockPartService.GetPartsByType(type);
           return Ok(stockParts); 
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}