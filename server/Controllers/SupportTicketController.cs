namespace PCpals.Controllers;

[ApiController]
[Route("api/supportTicket")]

public class SupportTicketController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly SupportTicketService supportTicketService;

    public SupportTicketController(Auth0Provider auth, SupportTicketService supportTicketService){
        this.auth = auth;
        this.supportTicketService = supportTicketService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SupportTickets>> CreateSupportTicket(SupportTickets ticketData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            ticketData.CreatorId = userInfo.Id;
            SupportTickets supportTickets = supportTicketService.CreateSupportTickets(ticketData);
            return Ok(supportTickets);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<SupportTickets>> GetSupportTickets(){
        try
        {
            List<SupportTickets> supportTickets = supportTicketService.GetSupportTickets();
            return Ok(supportTickets);
        }
         catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}