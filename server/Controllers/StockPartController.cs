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

    [HttpGet("{type}/intel")]
    public ActionResult<List<StockPart>> GetIntelPartsByType(string type){
        try
        {
           List<StockPart> stockParts = stockPartService.GetIntelPartsByType(type);
           return Ok(stockParts); 
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{type}/amd")]
    public ActionResult<List<StockPart>> GetAMDPartsByType(string type){
        try
        {
           List<StockPart> stockParts = stockPartService.GetAMDPartsByType(type);
           return Ok(stockParts); 
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet("{type}/motherB")]
    public ActionResult<List<StockPart>> GetMotherBoards(string type){
      try
      {
        List<StockPart> stockParts = stockPartService.GetMotherBoards(type);
        return Ok(stockParts);
      }
       catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    
    [HttpDelete("{partId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteStockPart(int partId){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = stockPartService.DeleteStockPart(partId, userInfo.Id);
            return Ok(message);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}